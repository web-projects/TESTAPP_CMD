using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.FileIO;
using TestApp.Hashing;
using TestApp.Helpers;
using TestApp.Strings;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //IsNullTest();

            //TestBytes();

            //RunUnitTests();
            //RunTaskDemo().Wait();

            //TestDecryptor();

            // ENUMS TEST
            int result = 0x9F13;
            VipaSW1SW2Codes code = (VipaSW1SW2Codes) result;
            Console.WriteLine($"VIPA ERROR={code.GetStringValue()}");

            // SLOT 0
            int slot0 = GetSlotNumber(0);

            // SLOT 8
            int slot8 = GetSlotNumber(8);

            Console.ReadKey();
        }

        static int GetSlotNumber(int slot)
        {
            ProcessFile fp = new ProcessFile();
            int result = fp.GetSlotNumber(slot);
            Console.WriteLine($"FOR REQUESTED SLOT#{slot} - MAPP_VSD_SRED.CFG SLOT={slot}");
            return result;
        }

        static void TestDecryptor()
        {
            //------------------------ PRIMARY PAN HASH ---------------------------------------------
            //string primaryPAN = "34313131313131313131313131313131";
            //byte[] data = Encoding.ASCII.GetBytes(primaryPAN);
            //string dump = ByteArrayToString(data);

            //string encryptedPrimaryPAN = HMACHash.Encrypt(Encoding.ASCII.GetString(data), HMACValidator.MACSecondaryHASH);
            //string primaryPANKeySalt = ByteArrayToString(UTF8Encoding.UTF8.GetBytes(encryptedPrimaryPAN));
            //0x76, 0x58, 0x38, 0x6c, 0x36, 0x53, 0x4f, 0x6d, 0x53, 0x76, 0x6d, 0x70, 0x57, 0x52, 0x69, 0x36, 0x41, 0x44, 0x6e, 0x53, 0x73, 0x71, 0x6c, 0x5a, 0x47, 0x4c, 0x6f, 0x41, 0x4f, 0x64, 0x4b, 0x79, 0x71, 0x56, 0x6b, 0x59, 0x75, 0x67, 0x41, 0x35, 0x30, 0x72, 0x4b, 0x41, 0x4e, 0x77, 0x4e, 0x41, 0x35, 0x4d, 0x2b, 0x6e, 0x78, 0x41, 0x3d, 0x3d

            // DECRYPT PRIMARY PAN HASH: "34313131313131313131313131313131"
            string primaryPANHASH = HMACHash.Decrypt(Encoding.ASCII.GetString(HMACValidator.MACPrimaryPANSalt),
                HMACValidator.MACSecondaryHASH);
            Console.WriteLine($"DECRYPTED PRIMARY PAN: {primaryPANHASH}");

            //------------------------ PRIMARY HMAC HASH ---------------------------------------------
            //string primaryHash = "98A8AAED5A2BA9E228B138274FDF546D6688D2AB8D9A36E0A50A5BF3B142AFB0";
            //byte[] data = Encoding.ASCII.GetBytes(primaryHash);
            //string dump = ByteArrayToString(data);

            //byte[] MACPrimaryHASH = new byte [] { 0x39, 0x38, 0x41, 0x38, 0x41, 0x41, 0x45, 0x44, 0x35, 0x41, 0x32, 0x42, 0x41, 0x39, 0x45, 0x32, 0x32, 0x38, 0x42, 0x31, 0x33, 0x38, 0x32, 0x37, 0x34, 0x46, 0x44, 0x46, 0x35, 0x34, 0x36, 0x44, 0x36, 0x36, 0x38, 0x38, 0x44, 0x32, 0x41, 0x42, 0x38, 0x44, 0x39, 0x41, 0x33, 0x36, 0x45, 0x30, 0x41, 0x35, 0x30, 0x41, 0x35, 0x42, 0x46, 0x33, 0x42, 0x31, 0x34, 0x32, 0x41, 0x46, 0x42, 0x30 };

            //string encryptedPrimaryHash = HMACHash.Encrypt(Encoding.ASCII.GetString(data), HMACValidator.MACSecondaryHASH);
            //string primaryKeySalt = ByteArrayToString(UTF8Encoding.UTF8.GetBytes(encryptedPrimaryHash));
            //0x5a, 0x2b, 0x50, 0x66, 0x4d, 0x4c, 0x55, 0x76, 0x36, 0x64, 0x76, 0x46, 0x4f, 0x77, 0x72, 0x31, 0x4d, 0x75, 0x36, 0x50, 0x63, 0x76, 0x58, 0x30, 0x68, 0x45, 0x67, 0x6c, 0x57, 0x71, 0x38, 0x6e, 0x6e, 0x57, 0x74, 0x5a, 0x58, 0x33, 0x2b, 0x6c, 0x45, 0x79, 0x59, 0x38, 0x77, 0x58, 0x37, 0x67, 0x7a, 0x6c, 0x49, 0x56, 0x51, 0x69, 0x53, 0x76, 0x58, 0x65, 0x76, 0x57, 0x66, 0x56, 0x4b, 0x78, 0x6c, 0x6a, 0x45, 0x49, 0x4e, 0x49, 0x52, 0x42, 0x30, 0x2f, 0x43, 0x79, 0x69, 0x51, 0x50, 0x62, 0x4d, 0x55, 0x62, 0x30, 0x36, 0x59, 0x41, 0x33, 0x41, 0x30, 0x44, 0x6b, 0x7a, 0x36, 0x66, 0x45
            //Console.WriteLine($"ENCRYPTED PRIMARY HASH: {encrypted}");

            //string decrypted = HMACHash.Decrypt(encrypted);
            //Console.WriteLine($"DECRYPTED PRIMARY HASH: {decrypted}"); 

            // DECRYPT PRIMARY HASH: "98A8AAED5A2BA9E228B138274FDF546D6688D2AB8D9A36E0A50A5BF3B142AFB0"
            string primaryHASH = HMACHash.Decrypt(Encoding.ASCII.GetString(HMACValidator.MACPrimaryHASHSalt),
                HMACValidator.MACSecondaryHASH);
            Console.WriteLine($"DECRYPTED PRIMARY HASH: {primaryHASH}");

            //------------------------ SECONDARY HMAC HASH ---------------------------------------------
            //string secondaryHash = "D1F8827DD9276F9F80F8890D3E607AC03CA022BA91B8024356DCDF54AD434F83";
            //byte [] secondaryHashData = Encoding.ASCII.GetBytes(secondaryHash);
            //string dump = ByteArrayToString(data);
            //0x44, 0x31, 0x46, 0x38, 0x38, 0x32, 0x37, 0x44, 0x44, 0x39, 0x32, 0x37, 0x36, 0x46, 0x39, 0x46, 0x38, 0x30, 0x46, 0x38, 0x38, 0x39, 0x30, 0x44, 0x33, 0x45, 0x36, 0x30, 0x37, 0x41, 0x43, 0x30, 0x33, 0x43, 0x41, 0x30, 0x32, 0x32, 0x42, 0x41, 0x39, 0x31, 0x42, 0x38, 0x30, 0x32, 0x34, 0x33, 0x35, 0x36, 0x44, 0x43, 0x44, 0x46, 0x35, 0x34, 0x41, 0x44, 0x34, 0x33, 0x34, 0x46, 0x38, 0x33

            //string decrypted = HMACHash.Decrypt(Encoding.ASCII.GetString(HMACValidator.MACSecondaryHASH));
            //Console.WriteLine($"DECRYPTED PRIMARY HASH: {decrypted}");

            //string encryptedSecondaryHash = HMACHash.Encrypt(Encoding.ASCII.GetString(secondaryHashData), HMACValidator.MACPrimaryHASH);
            //string secondaryKeySalt = ByteArrayToString(UTF8Encoding.UTF8.GetBytes(encryptedSecondaryHash));
            //0x69, 0x76, 0x70, 0x7a, 0x71, 0x51, 0x59, 0x4f, 0x38, 0x59, 0x67, 0x6f, 0x51, 0x4c, 0x79, 0x35, 0x36, 0x38, 0x67, 0x73, 0x72, 0x51, 0x53, 0x34, 0x39, 0x62, 0x6f, 0x48, 0x65, 0x52, 0x70, 0x75, 0x37, 0x44, 0x72, 0x37, 0x79, 0x58, 0x6a, 0x4c, 0x32, 0x6d, 0x71, 0x46, 0x45, 0x6e, 0x34, 0x32, 0x56, 0x37, 0x44, 0x41, 0x2f, 0x4c, 0x4e, 0x63, 0x42, 0x70, 0x6d, 0x4e, 0x4d, 0x58, 0x48, 0x6d, 0x6b, 0x43, 0x32, 0x6b, 0x6c, 0x6c, 0x6a, 0x33, 0x32, 0x7a, 0x4b, 0x72, 0x54, 0x69, 0x32, 0x4c, 0x4c, 0x72, 0x54, 0x38, 0x4f, 0x57, 0x2f, 0x4c, 0x6b, 0x41, 0x4a, 0x4e, 0x4f, 0x47, 0x56, 0x73

            // DECRYPT SECONDARY HASH: "D1F8827DD9276F9F80F8890D3E607AC03CA022BA91B8024356DCDF54AD434F83"
            string secondaryHASH = HMACHash.Decrypt(Encoding.ASCII.GetString(HMACValidator.MACSecondaryHASHSalt),
                HMACValidator.MACPrimaryHASH);
            Console.WriteLine($"DECRYPTED SECONDARY HASH: {secondaryHASH}");

            Console.ReadKey();
        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
            {
                hex.AppendFormat("0x{0:x2}, ", b);
            }
            return hex.ToString();
        }

        static void IsNullTest()
        {
            Foo foo = null;

            if (foo is null)
            { 
                Console.WriteLine("foo is null"); // This condition is met
            }

            if (foo == null)
            {
                Console.WriteLine("foo == null"); // This will throw an exception
            }
        }

        static void TestBytes()
        {
            string value = "\0\b";
            byte[] Bytes = Encoding.UTF8.GetBytes(value);
            byte[] Sequence1 = new byte[] { 0x00, (byte)DeviceKeys.KEY_STOP };
            byte[] Sequence2 = new byte[] { 0x00, (byte)DeviceKeys.KEY_CANCEL };

            if (Encoding.UTF8.GetBytes(value).SequenceEqual(new byte[] { 0x00, (byte)DeviceKeys.KEY_CORR }))
            {
                Console.WriteLine("USER CANCELLED");
            }
        }

        static void RunUnitTests()
        {
            TestUnit test = new TestUnit();
            bool found = test.RunTests();
            test.Log(string.Format("INSTALL DRIVERS={0}", found), LogType.Info);
        }

        private static async Task RunTaskDemo()
        {
            Console.WriteLine("About to launch a task...");
            _ = Task.Run(async () =>
            {
                await Task.Delay(100).ConfigureAwait(false);
                throw new InvalidOperationException();
            });
            await Task.Delay(5000);
            Console.WriteLine("Exiting after 5 second delay");
        }
    }

    public class Foo
    {
        public static bool operator ==(Foo foo1, Foo foo2)
        {
            if (object.Equals(foo2, null))
            { 
                throw new Exception("oops");
            }

            return object.Equals(foo1, foo2);
        }

        public static bool operator !=(Foo foo1, Foo foo2)
        {
            if (!object.Equals(foo2, null))
            {
                throw new Exception("oops");
            }

            return object.Equals(foo1, foo2);
        }
    }
}
