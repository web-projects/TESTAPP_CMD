using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.IO;

namespace TestApp
{
    public enum LogType
    {
        Info    = 0,
        Warning = 1,
        Error   = 2
    }

    class TestUnit
    {
        private const string logFileDir = @"C:\TrustCommerce\logs\";
        private const string logFile = logFileDir + "IPAInstallation.log";

        public bool RunTests()
        {
            return IngenicoDriverNeeded();
        }

        public void Log(string entry, LogType logType)
        {
            if (File.Exists(logFile))
            {
                using (StreamWriter sw = File.AppendText(logFile))
                {
                    RecordLog(entry, sw, logType);
                    sw.Close(); //It appeared this was buffering the writes, forcing the close forces the write
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(logFile))
                {
                    sw.WriteLine("TCIPA Installation Process Log Records");
                    sw.WriteLine("Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
                    RecordLog(entry, sw, logType);
                    sw.Close(); //It appeared this was buffering the writes, forcing the close forces the write
                }
            }
        }

        private static void RecordLog(string entry, TextWriter writer, LogType logType)
        {
            writer.WriteLine("\r\n{0} {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());
            switch (logType)
            {
                case LogType.Error:
                    writer.Write(" Error");
                    break;
                case LogType.Info:
                    writer.Write(" Info");
                    break;
                case LogType.Warning:
                    writer.Write(" Warning");
                    break;
            }

            writer.WriteLine(": {0}", entry);
            writer.WriteLine("----------------------------------------------");
        }

        private static bool IngenicoDriverNeeded()
        {
            var devicesFound = DevicesAttached();
            bool driverNeeded = devicesFound.Length == 1;
            if (driverNeeded)
            {
                driverNeeded = !(devicesFound[0].Equals("IDTECH"));
            }
            return driverNeeded;
        }

        private static string[] DevicesAttached()
        {
            const string INGNAR = "0b00"; //Do NOT make this uppercase
            const string IDTECH = "0acd";

            ManagementObjectCollection collection;
            var deviceList = new List<string>();
            var nonUSBDeviceList = new List<string>();
            using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_PnPEntity"))
            {
                collection = searcher.Get();
            }
            string ingenicoVID = string.Format("vid_{0}", INGNAR);
            string IDTechVID = string.Format("vid_{0}", IDTECH);
            foreach (var device in collection)
            {
                var deviceID = ((string)device.GetPropertyValue("DeviceID") ?? "").ToLower();
                if (string.IsNullOrWhiteSpace(deviceID) || !deviceID.Contains("vid_"))
                    continue;
                if (deviceID.Contains("usb\\") && (deviceID.Contains(ingenicoVID) || deviceID.Contains(IDTechVID)))
                {
                    deviceList.Add((deviceID.Contains(IDTechVID) ? "IDTECH" : "INGENICO"));
                }
                else if (deviceID.Contains(ingenicoVID) || deviceID.Contains(IDTechVID))
                {
                    nonUSBDeviceList.Add((deviceID.Contains(IDTechVID) ? "IDTECH" : "INGENICO"));
                }
            }
            if (deviceList.Count == 0 && nonUSBDeviceList.Count == 1)
                deviceList.Add(nonUSBDeviceList[0]);
            return deviceList.ToArray();
        }
    }
}
