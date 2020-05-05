using System;
using System.IO;
using System.Linq;
using System.Text;

namespace TestApp.FileIO
{
    public class ProcessFile
    {
        private const int SLOT_OFFSET = 251;
        private const int SLOT_LENGTH = 6;
        private const string FileName = @"Resources\mapp_vsd_sred.cfg";
        private readonly string TargetFile = Path.Combine(Directory.GetCurrentDirectory(), FileName);

        private string GetLineInFile(string search)
        {
            string[] lines = File.ReadAllLines(TargetFile);
            return lines.Select(x => x).Where(y => y.IndexOf(search) > -1).FirstOrDefault();
        }

        private string GetStreamInFile()
        {
            byte[] buffer;
            FileStream fileStream = new FileStream(TargetFile, FileMode.Open, FileAccess.Read);
            try
            {
                buffer = new byte[SLOT_LENGTH];
                fileStream.Seek(SLOT_OFFSET, 0);
                fileStream.Read(buffer, 0, SLOT_LENGTH);
            }
            finally
            {
                fileStream.Close();
            }
            return Encoding.UTF8.GetString(buffer);
        }

        public int GetSlotNumber()
        {
            //string search = GetLineInFile("slot=");
            string search = GetStreamInFile();

            if (!string.IsNullOrEmpty(search))
            {
                string [] result = search.Split('=');
                if (result.Length == 2)
                {
                    return Convert.ToInt16(result[1]);
                }
            }
            return -1;
        }
    }
}
