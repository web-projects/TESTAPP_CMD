using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using TestApp.Dictionary;
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

            TestDecryptor();

            // ENUMS TEST
            //int result = 0x9F13;
            //VipaSW1SW2Codes code = (VipaSW1SW2Codes) result;
            //Console.WriteLine($"VIPA ERROR={code.GetStringValue()}");

            // SLOT 0
            //int slot0 = GetSlotNumber(0);

            // SLOT 8
            //int slot8 = GetSlotNumber(8);

            //Console.ReadKey();

            //string paymentType = TestTuples("A0000000031010");
            //Console.WriteLine($"PAYMENT TYPE='{paymentType}'");

            //string serial = ByteArrayCodedHextoString(new byte[] { 0x39, 0x38, 0x37, 0x30, 0x39, 0x31, 0x36, 0x33, 0x36 });
            //Console.WriteLine($"PAYMENT TYPE='{serial}'");
        }

        public static string ByteArrayCodedHextoString(byte[] data)
        {
            string result = string.Empty;

            foreach(byte value in data)
            {
                result += value - 0x30;
            }

            return result;
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
            const string MACPrimaryPAN    = "34313131313131313131313131313131";
            const string MACPrimarySlot   = "98A8AAED5A2BA9E228B138274FDF546D6688D2AB8D9A36E0A50A5BF3B142AFB0";
            const string MACSecondarySlot = "D1F8827DD9276F9F80F8890D3E607AC03CA022BA91B8024356DCDF54AD434F83";

            // #1) HMACValidator.MACSecondaryKeyHASH
            byte[] MACSecondaryKeyHASH = Encoding.ASCII.GetBytes(MACSecondarySlot);
            Debug.WriteLine($"MACSecondaryKeyHASH _____: {ByteArrayToString(MACSecondaryKeyHASH)}");

            //------------------------ PRIMARY PAN SALT ---------------------------------------------
            byte[] MACPrimaryPANData = Encoding.ASCII.GetBytes(MACPrimaryPAN);
            string MACPrimaryPANDataStr = ByteArrayToString(MACPrimaryPANData);

            // #2) HMACValidator.MACPrimaryPANHASH -----------------------------------------------------------------------------
            string encryptedPrimaryPAN = HMACHash.Encrypt(Encoding.ASCII.GetString(MACPrimaryPANData), HMACValidator.MACSecondaryKeyHASH);
            string primaryPANKeySalt = ByteArrayToString(UTF8Encoding.UTF8.GetBytes(encryptedPrimaryPAN));
            //0x76, 0x58, 0x38, 0x6c, 0x36, 0x53, 0x4f, 0x6d, 0x53, 0x76, 0x6d, 0x70, 0x57, 0x52, 0x69, 0x36, 0x41, 0x44, 0x6e, 0x53, 0x73, 0x71, 0x6c, 0x5a, 0x47, 0x4c, 0x6f, 0x41, 0x4f, 0x64, 0x4b, 0x79, 0x71, 0x56, 0x6b, 0x59, 0x75, 0x67, 0x41, 0x35, 0x30, 0x72, 0x4b, 0x41, 0x4e, 0x77, 0x4e, 0x41, 0x35, 0x4d, 0x2b, 0x6e, 0x78, 0x41, 0x3d, 0x3d
            Debug.WriteLine($"MACPrimaryPANSalt _______: {primaryPANKeySalt}");

            // DECRYPT PRIMARY PAN HASH: "34313131313131313131313131313131"
            string primaryPANSalt = HMACHash.Decrypt(Encoding.ASCII.GetString(HMACValidator.MACPrimaryPANSalt), HMACValidator.MACSecondaryKeyHASH);
            Console.WriteLine($"DECRYPTED PRIMARY PAN : {primaryPANSalt}");
            Debug.WriteLine($"DECRYPTED PRIMARY PAN ___: {primaryPANSalt}");

            //------------------------ PRIMARY HMAC HASH ---------------------------------------------
            byte[] primaryHashData = Encoding.ASCII.GetBytes(MACPrimarySlot);
            string primaryHashDataStr = ByteArrayToString(primaryHashData);
            //Debug.WriteLine($"MACPrimarySlot __________: {primaryHashDataStr}");

            // #3) HMACValidator.MACPrimaryHASHSalt -------------------------------------------------------------------------------------
            // 39384138414145443541324241394532323842313338323734464446353436443636383844324142384439413336453041353041354246334231343241464230
            string encryptedPrimaryHashSalt = HMACHash.Encrypt(Encoding.ASCII.GetString(primaryHashData), HMACValidator.MACSecondaryKeyHASH);
            string primaryKeySalt = ByteArrayToString(UTF8Encoding.UTF8.GetBytes(encryptedPrimaryHashSalt));
            //0x5a, 0x2b, 0x50, 0x66, 0x4d, 0x4c, 0x55, 0x76, 0x36, 0x64, 0x76, 0x46, 0x4f, 0x77, 0x72, 0x31, 0x4d, 0x75, 0x36, 0x50, 0x63, 0x76, 0x58, 0x30, 0x68, 0x45, 0x67, 0x6c, 0x57, 0x71, 0x38, 0x6e, 0x6e, 0x57, 0x74, 0x5a, 0x58, 0x33, 0x2b, 0x6c, 0x45, 0x79, 0x59, 0x38, 0x77, 0x58, 0x37, 0x67, 0x7a, 0x6c, 0x49, 0x56, 0x51, 0x69, 0x53, 0x76, 0x58, 0x65, 0x76, 0x57, 0x66, 0x56, 0x4b, 0x78, 0x6c, 0x6a, 0x45, 0x49, 0x4e, 0x49, 0x52, 0x42, 0x30, 0x2f, 0x43, 0x79, 0x69, 0x51, 0x50, 0x62, 0x4d, 0x55, 0x62, 0x30, 0x36, 0x59, 0x41, 0x33, 0x41, 0x30, 0x44, 0x6b, 0x7a, 0x36, 0x66, 0x45
            Console.WriteLine($"MACPrimaryHASHSalt: {encryptedPrimaryHashSalt}");
            Debug.WriteLine($"MACPrimaryHASHSalt ______: {primaryKeySalt}");

            //string decrypted = HMACHash.Decrypt(encryptedPrimaryHash, HMACValidator.MACSecondaryKeyHASH);
            //Console.WriteLine($"DECRYPTED PRIMARY HASH: {decrypted}");
            //Debug.WriteLine($"DECRYPTED PRIMARY HASH __: {decrypted}");

            //string hmacPrimaryHashData = Encoding.ASCII.GetString(HMACValidator.MACPrimaryHASHSalt);
            //string hmacEncryptedPrimaryHash = HMACHash.Encrypt(hmacPrimaryHashData, HMACValidator.MACSecondaryHASH);
            ////string hmacEncryptedPrimaryHash = HMACHash.Encrypt(hmacPrimaryHashData, primaryHashData);
            //byte[] hmacEncryptedPrimaryHashData = Encoding.ASCII.GetBytes(hmacEncryptedPrimaryHash);
            //Debug.WriteLine($"DECRYPTED PRIMARY HASH  : {ByteArrayToString(hmacEncryptedPrimaryHashData)}");

            // DECRYPT PRIMARY HASH: "98A8AAED5A2BA9E228B138274FDF546D6688D2AB8D9A36E0A50A5BF3B142AFB0"
            string primaryHASH = HMACHash.Decrypt(Encoding.ASCII.GetString(HMACValidator.MACPrimaryHASHSalt), HMACValidator.MACSecondaryKeyHASH);
            Console.WriteLine($"DECRYPTED PRIMARY HASH: {primaryHASH}");
            Debug.WriteLine($"DECRYPTED PRIMARY HASH __: {primaryHASH}");

            //------------------------ SECONDARY HMAC HASH ---------------------------------------------
            byte [] secondaryHashData = Encoding.ASCII.GetBytes(MACSecondarySlot);
            string secondaryHashDataStr = ByteArrayToString(secondaryHashData);
            //0x44, 0x31, 0x46, 0x38, 0x38, 0x32, 0x37, 0x44, 0x44, 0x39, 0x32, 0x37, 0x36, 0x46, 0x39, 0x46, 0x38, 0x30, 0x46, 0x38, 0x38, 0x39, 0x30, 0x44, 0x33, 0x45, 0x36, 0x30, 0x37, 0x41, 0x43, 0x30, 0x33, 0x43, 0x41, 0x30, 0x32, 0x32, 0x42, 0x41, 0x39, 0x31, 0x42, 0x38, 0x30, 0x32, 0x34, 0x33, 0x35, 0x36, 0x44, 0x43, 0x44, 0x46, 0x35, 0x34, 0x41, 0x44, 0x34, 0x33, 0x34, 0x46, 0x38, 0x33

            //string decryptedSecondaryHash = HMACHash.Encrypt(secondaryHash, HMACValidator.MACPrimaryPANSalt);
            //string decryptedSecondaryHash = HMACHash.Encrypt(primaryHash, HMACValidator.MACPrimaryPANSalt);
            //Console.WriteLine($"SECONDARY HASH: {decryptedSecondaryHash}");
            //Debug.WriteLine($"SECONDARY HASH  : {decryptedSecondaryHash}");

            //------------------------ PRIMARY KEY HASH ---------------------------------------------
            // #4) HMACValidator.MACPrimaryKeyHASH
            //byte[] MACPrimaryHASH = new byte [] { 0x39, 0x38, 0x41, 0x38, 0x41, 0x41, 0x45, 0x44, 0x35, 0x41, 0x32, 0x42, 0x41, 0x39, 0x45, 0x32, 0x32, 0x38, 0x42, 0x31, 0x33, 0x38, 0x32, 0x37, 0x34, 0x46, 0x44, 0x46, 0x35, 0x34, 0x36, 0x44, 0x36, 0x36, 0x38, 0x38, 0x44, 0x32, 0x41, 0x42, 0x38, 0x44, 0x39, 0x41, 0x33, 0x36, 0x45, 0x30, 0x41, 0x35, 0x30, 0x41, 0x35, 0x42, 0x46, 0x33, 0x42, 0x31, 0x34, 0x32, 0x41, 0x46, 0x42, 0x30 };
            // WHERE THIS THIS COME FROM ???
            //0x79, 0x32, 0x6d, 0x61, 0x6b, 0x33, 0x4a, 0x43, 0x37, 0x41, 0x63, 0x54, 0x68, 0x4b, 0x6f, 0x79, 0x70, 0x63, 0x44, 0x62, 0x41, 0x6a, 0x33, 0x4b, 0x64, 0x54, 0x32, 0x36, 0x52, 0x6e, 0x32, 0x71, 0x63, 0x52, 0x50, 0x36, 0x61, 0x30, 0x65, 0x4e, 0x43, 0x48, 0x58, 0x6c, 0x46, 0x71, 0x6e, 0x52, 0x71, 0x39, 0x48, 0x42, 0x4f, 0x63, 0x6e, 0x69, 0x31, 0x53, 0x61, 0x79, 0x4b, 0x69, 0x76, 0x6e, 0x68, 0x50, 0x4b, 0x4f, 0x42, 0x31, 0x69, 0x52, 0x44, 0x4e, 0x52, 0x49, 0x71, 0x49, 0x36, 0x45, 0x48, 0x78, 0x64, 0x35, 0x66, 0x49, 0x68, 0x44, 0x59, 0x63, 0x72, 0x34, 0x35, 0x54, 0x69, 0x62
            ///HMACHash.Decrypt(Encoding.ASCII.GetString(HMACValidator.MACSecondaryHASHSalt), HMACValidator.MACPrimaryKeyHASH);
            //string encryptedPrimaryKeyHash = HMACHash.Encrypt(MACSecondarySlot, HMACValidator.MACSecondaryHASHSalt);
            //string encryptedPrimaryKeyHash = HMACHash.Encrypt(Encoding.ASCII.GetString(HMACValidator.MACSecondaryHASHSalt), secondaryHashData);
            string encryptedPrimaryKeyHash = HMACHash.Encrypt(Encoding.ASCII.GetString(secondaryHashData), HMACValidator.MACSecondaryHASHSalt);
            string primaryKeyHash = ByteArrayToString(UTF8Encoding.UTF8.GetBytes(encryptedPrimaryKeyHash));
            Debug.WriteLine($"MACPrimaryKeyHASH _______: {primaryKeyHash}");

            // #5) HMACValidator.MACSecondaryHASHSalt -------------------------------------------------------------------------------------
            string encryptedSecondaryHash = HMACHash.Encrypt(Encoding.ASCII.GetString(secondaryHashData), HMACValidator.MACPrimaryKeyHASH);
            string secondaryKeySalt = ByteArrayToString(UTF8Encoding.UTF8.GetBytes(encryptedSecondaryHash));
            Debug.WriteLine($"MACSecondaryHASHSalt ____: {secondaryKeySalt}");
            //0x69, 0x76, 0x70, 0x7a, 0x71, 0x51, 0x59, 0x4f, 0x38, 0x59, 0x67, 0x6f, 0x51, 0x4c, 0x79, 0x35, 0x36, 0x38, 0x67, 0x73, 0x72, 0x51, 0x53, 0x34, 0x39, 0x62, 0x6f, 0x48, 0x65, 0x52, 0x70, 0x75, 0x37, 0x44, 0x72, 0x37, 0x79, 0x58, 0x6a, 0x4c, 0x32, 0x6d, 0x71, 0x46, 0x45, 0x6e, 0x34, 0x32, 0x56, 0x37, 0x44, 0x41, 0x2f, 0x4c, 0x4e, 0x63, 0x42, 0x70, 0x6d, 0x4e, 0x4d, 0x58, 0x48, 0x6d, 0x6b, 0x43, 0x32, 0x6b, 0x6c, 0x6c, 0x6a, 0x33, 0x32, 0x7a, 0x4b, 0x72, 0x54, 0x69, 0x32, 0x4c, 0x4c, 0x72, 0x54, 0x38, 0x4f, 0x57, 0x2f, 0x4c, 0x6b, 0x41, 0x4a, 0x4e, 0x4f, 0x47, 0x56, 0x73

            // DECRYPT SECONDARY HASH: "D1F8827DD9276F9F80F8890D3E607AC03CA022BA91B8024356DCDF54AD434F83"
            string secondaryHASH = HMACHash.Decrypt(Encoding.ASCII.GetString(HMACValidator.MACSecondaryHASHSalt), HMACValidator.MACPrimaryKeyHASH);
            Console.WriteLine($"DECRYPTED SECONDARY HASH: {secondaryHASH}");
            Debug.WriteLine($"DECRYPTED SECONDARY HASH : {secondaryHASH}");

            Console.ReadKey();
        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
            {
                hex.AppendFormat("0x{0:x2}, ", b);
            }
            return hex.ToString().TrimEnd(' ').TrimEnd(',');
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

        private static string TestTuples(string paymentAID)
        {
            string transactionType = string.Empty;
            var elements = AidList.aidList.Select(x => x).Where(y => y.Key.Equals(AidList.CATEGORY_FIRSTDATA));
            foreach (var element in elements)
            {
                if (element.Value.cashbackAid.aidList.Any(x => x.Contains(paymentAID)))
                {
                    transactionType = element.Value.cashbackAid.transactionType;
                    break;
                }
                else if (element.Value.creditAid.aidList.Any(x => x.Contains(paymentAID)))
                {
                    transactionType = element.Value.creditAid.transactionType;
                    break;
                }
                else if (element.Value.debitAid.aidList.Any(x => x.Contains(paymentAID)))
                {
                    transactionType = element.Value.debitAid.transactionType;
                    break;
                }
                if (element.Value.mastercardAid.aidList.Any(x => x.Contains(paymentAID)))
                {
                    transactionType = element.Value.mastercardAid.transactionType;
                    break;
                }
            }

            return transactionType;
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
