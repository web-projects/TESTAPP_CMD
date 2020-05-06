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
        private const string CfgSlot0 = @"Resources\mapp_vsd_sred-slot0.cfg";
        private const string CfgSlot8 = @"Resources\mapp_vsd_sred-slot8.cfg";
        private readonly string TargetFile = Path.Combine(Directory.GetCurrentDirectory(), FileName);
        private readonly string MappSlot0 = Path.Combine(Directory.GetCurrentDirectory(), CfgSlot0);
        private readonly string MappSlot8 = Path.Combine(Directory.GetCurrentDirectory(), CfgSlot8);

        private string GetLineInFile(string search)
        {
            string[] lines = File.ReadAllLines(TargetFile);
            return lines.Select(x => x).Where(y => y.IndexOf(search) > -1).FirstOrDefault();
        }

        private string GetStreamInFile(int slot)
        {
            byte[] buffer;

            FileStream fileStream = null;

            switch(slot)
            {
                case 0:
                {
                    fileStream = new FileStream(MappSlot0, FileMode.Open, FileAccess.Read);
                    break;
                }

                case 8:
                {
                    fileStream = new FileStream(MappSlot8, FileMode.Open, FileAccess.Read);
                    break;
                }
            }

            try
            {
                buffer = new byte[SLOT_LENGTH];
                fileStream.Seek(SLOT_OFFSET, 0);
                fileStream.Read(buffer, 0, SLOT_LENGTH);
                if (buffer[0] != 's')
                {
                    fileStream.Seek(SLOT_OFFSET + 1, 0);
                    fileStream.Read(buffer, 0, SLOT_LENGTH);
                }
            }
            finally
            {
                fileStream.Close();
            }
            return Encoding.UTF8.GetString(buffer);
        }

        public int GetSlotNumber(int slot)
        {
            //string search = GetLineInFile("slot=");
            string search = GetStreamInFile(slot);

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
