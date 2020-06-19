using System.Collections.Generic;
using TestApp.Helpers;

namespace TestApp.Dictionary
{
    public class AidList
    {
        #region --- COMMON ELEMENTS ---
        public enum TransactionType
        {
            [StringValue("cashback")]
            Cashback,
            [StringValue("credit")]
            Credit,
            [StringValue("debit")]
            Debit,
            [StringValue("mastercard")]
            MasterCard,
        };
        #endregion --- COMMON ELEMENTS ---

        #region --- CATEGORY_DEFAULT ---
        /// <summary>
        /// DEFAULT AIDS
        /// </summary>
        public const string CATEGORY_DEFAULT = "DEFAULT";

        // 1) Discover, 2) MasterCard U.S. Maestro common debit, 3) Visa common debit, 4) MasterCard International Maestro
        public static readonly string[] CD_AID_CASHBACK_LIST = { "A0000001523010", "A0000000042203", "A0000000980840", "A0000000043060" };
        public static readonly (string transactionType, string[] aidList) CD_AID_CASHBACK = (StringValueAttribute.GetStringValue(TransactionType.Cashback), CD_AID_CASHBACK_LIST);

        // 1) MasterCard Credit, 2) MasterCard US Maestro, 3) Visa Common Debit
        public static readonly string[] CD_AID_CREDIT_LIST = { "A0000000041010", "A0000000042203", "A0000000980840" };
        public static readonly (string transactionType, string[] aidList) CD_AID_CREDIT = (StringValueAttribute.GetStringValue(TransactionType.Credit), CD_AID_CREDIT_LIST);

        // 1) MasterCard International Maestro
        public static readonly string[] CD_AID_DEBIT_LIST = { "A0000000043060" };
        public static readonly (string transactionType, string[] aidList) CD_AID_DEBIT = (StringValueAttribute.GetStringValue(TransactionType.Debit), CD_AID_DEBIT_LIST);

        // 1) MasterCard Credit
        public static readonly string[] CD_AID_MASTERCARD_LIST = { "A0000000041010" };
        public static readonly (string transactionType, string[] aidList) CD_AID_MASTERCARD = (StringValueAttribute.GetStringValue(TransactionType.MasterCard), CD_AID_MASTERCARD_LIST);
        #endregion --- CATEGORY_DEFAULT ---

        #region --- CATEGORY_VITAL ---
        /// <summary>
        /// VITAL AIDS
        /// </summary>
        public const string CATEGORY_VITAL = "VITAL";

        // 1) MasterCard International Maestro, 2) MasterCard U.S. Maestro common debit, 3) Visa common debit, 4) Visa Electron, 5) Visa Interlink
        public static readonly string[] CV_AID_CASHBACK_LIST = { "A0000000043060", "A0000000042203", "A0000000980840", "A0000000032010", "A0000000033010" };
        public static readonly (string transactionType, string[] aidList) CV_AID_CASHBACK = (StringValueAttribute.GetStringValue(TransactionType.Cashback), CV_AID_CASHBACK_LIST);

        // 1) Amex, 2) Diners, 3) Discover, 4) JCB, 5) MasterCard Credit, 6) Visa Electron, 7) Visa Credit and Visa Debit International
        public static readonly string[] CV_AID_CREDIT_LIST = { "A00000002501", "A0000001523010", "A0000003241010", "A0000000651010", "A0000000041010", "A0000000032010", "A0000000031010" };
        public static readonly (string transactionType, string[] aidList) CV_AID_CREDIT = (StringValueAttribute.GetStringValue(TransactionType.Credit), CV_AID_CREDIT_LIST);

        // 1) MasterCard International Maestro, 2) MasterCard U.S. Maestro common debit, 3) Visa common debit, 4) Visa Interlink
        public static readonly string[] CV_AID_DEBIT_LIST = { "A0000000043060", "A0000000042203", "A0000000980840", "A0000000033010" };
        public static readonly (string transactionType, string[] aidList) CV_AID_DEBIT = (StringValueAttribute.GetStringValue(TransactionType.Debit), CV_AID_DEBIT_LIST);

        // 1) MasterCard Credit
        public static readonly string[] CV_AID_MASTERCARD_LIST = { "A0000000041010" };
        public static readonly (string transactionType, string[] aidList) CV_AID_MASTERCARD = (StringValueAttribute.GetStringValue(TransactionType.MasterCard), CV_AID_MASTERCARD_LIST);
        #endregion --- CATEGORY_VITAL ---

        #region --- CATEGORY_PAYMENTECH ---
        /// <summary>
        /// PAYMENTECH-TANDEM AIDS
        /// </summary>
        public const string CATEGORY_PAYMENTECH = "PAYMENTECH-TANDEM";

        // 1) MasterCard International Maestro, 2) MasterCard U.S. Maestro common debit, 3) Visa common debit, 4) Discover
        public static readonly string[] CP_AID_CASHBACK_LIST = { "A0000000043060", "A0000000042203", "A0000000980840", "A0000001523010" };
        public static readonly (string transactionType, string[] aidList) CP_AID_CASHBACK = (StringValueAttribute.GetStringValue(TransactionType.Cashback), CP_AID_CASHBACK_LIST);

        // 1) Amex, 2) Diners, 3) Discover, 4) JCB, 5) MasterCard Credit, 6) Visa Electron, 7) Visa Credit and Visa Debit International
        public static readonly string[] CP_AID_CREDIT_LIST = { "A00000002501", "A0000001523010", "A0000003241010", "A0000000651010", "A0000000041010", "A0000000032010", "A0000000031010" };
        public static readonly (string transactionType, string[] aidList) CP_AID_CREDIT = (StringValueAttribute.GetStringValue(TransactionType.Credit), CP_AID_CREDIT_LIST);

        // 1) MasterCard International Maestro, 2) MasterCard U.S. Maestro common debit, 3) Visa common debit, 4) Visa Interlink, 5) Discover US Common Debit, 6) DNA US Common Debit
        public static readonly string[] CP_AID_DEBIT_LIST = { "A0000000043060", "A0000000042203", "A0000000980840", "A0000000033010", "A0000001524010", "A0000006200620" };
        public static readonly (string transactionType, string[] aidList) CP_AID_DEBIT = (StringValueAttribute.GetStringValue(TransactionType.Debit), CP_AID_DEBIT_LIST);

        // 1) MasterCard Credit
        public static readonly string[] CP_AID_MASTERCARD_LIST = { "A0000000041010" };
        public static readonly (string transactionType, string[] aidList) CP_AID_MASTERCARD = (StringValueAttribute.GetStringValue(TransactionType.MasterCard), CP_AID_MASTERCARD_LIST);
        #endregion --- CATEGORY_PAYMENTECH ---

        #region --- CATEGORY_FIRSTDATA ---
        /// <summary>
        /// FIRSTDATA RAPID CONNECT AIDS
        /// </summary>
        public const string CATEGORY_FIRSTDATA = "FIRSTDATA-RAPIDCONNECT";

        // 1) Discover, 2) MasterCard U.S. Maestro common debit, 3) Visa common debit, 4) MasterCard International Maestro
        public static readonly string[] CF_AID_CASHBACK_LIST = { "A0000001523010", "A0000000042203", "A0000000980840", "A0000000043060" };
        public static readonly (string transactionType, string[] aidList) CF_AID_CASHBACK = (StringValueAttribute.GetStringValue(TransactionType.MasterCard), CF_AID_CASHBACK_LIST);

        // 1) Amex, 2) MasterCard Credit, 3) MasterCard US Maestro, 4) Visa Common Debit, 5) Visa Electron, 6) Visa Credit and Visa Debit International
        public static readonly string[] CF_AID_CREDIT_LIST = { "A00000002501", "A0000000041010", "A0000000042203", "A0000000980840", "A0000000032010", "A0000000031010" };
        public static readonly (string transactionType, string[] aidList) CF_AID_CREDIT = (StringValueAttribute.GetStringValue(TransactionType.Credit), CF_AID_CREDIT_LIST);

        // 1) MasterCard International Maestro, 2) Visa Interlink Global Debit
        public static readonly string[] CF_AID_DEBIT_LIST = { "A0000000043060", "A0000000033010" };
        public static readonly (string transactionType, string[] aidList) CF_AID_DEBIT = (StringValueAttribute.GetStringValue(TransactionType.Debit), CF_AID_DEBIT_LIST);

        // 1) MasterCard Credit
        public static readonly string[] CF_AID_MASTERCARD_LIST = { "A0000000041010" };
        public static readonly (string transactionType, string[] aidList) CF_AID_MASTERCARD = (StringValueAttribute.GetStringValue(TransactionType.MasterCard), CF_AID_MASTERCARD_LIST);
        #endregion --- CATEGORY_FIRSTDATA ---

        #region --- CATEGORY_ELAVON ---
        /// <summary>
        /// ELAVON AIDS
        /// </summary>
        public const string CATEGORY_ELAVON = "ELAVON";

        // 1) MasterCard International Maestro, 2) MasterCard U.S. Maestro common debit, 3) Visa common debit, 4) Discover
        public static readonly string[] CE_AID_CASHBACK_LIST = { "A0000000043060", "A0000000042203", "A0000000980840", "A0000001523010" };
        public static readonly (string transactionType, string[] aidList) CE_AID_CASHBACK = (StringValueAttribute.GetStringValue(TransactionType.MasterCard), CE_AID_CASHBACK_LIST);

        // 1) Amex, 2) Diners, 3) Discover, 4) JCB, 5) MasterCard Credit, 6) Visa Electron, 7) Visa Credit and Visa Debit International
        public static readonly string[] CE_AID_CREDIT_LIST = { "A00000002501", "A0000001523010", "A0000003241010", "A0000000651010", "A0000000041010", "A0000000032010", "A0000000031010" };
        public static readonly (string transactionType, string[] aidList) CE_AID_CREDIT = (StringValueAttribute.GetStringValue(TransactionType.Credit), CE_AID_CREDIT_LIST);

        // 1) MasterCard International Maestro, 2) MasterCard U.S. Maestro common debit, 3) Visa common debit, 4) Visa Interlink, 5) Discover US Common Debit, 6) DNA US Common Debit  
        public static readonly string[] CE_AID_DEBIT_LIST = { "A0000000043060", "A0000000042203", "A0000000980840", "A0000000033010", "A0000001524010", "A0000006200620" };
        public static readonly (string transactionType, string[] aidList) CE_AID_DEBIT = (StringValueAttribute.GetStringValue(TransactionType.Debit), CE_AID_DEBIT_LIST);

        // 1) MasterCard Credit
        public static readonly string[] CE_AID_MASTERCARD_LIST = { "A0000000041010" };
        public static readonly (string transactionType, string[] aidList) CE_AID_MASTERCARD = (StringValueAttribute.GetStringValue(TransactionType.MasterCard), CE_AID_MASTERCARD_LIST);
        #endregion --- CATEGORY_ELAVON ---

        // AIDS CATEGORIZED BY PAYMENT SERVICER
        public static Dictionary<string, ((string transactionType, string[] aidList) cashbackAid, (string transactionType, string[] aidList) creditAid, (string transactionType, string[] aidList) debitAid, (string transactionType, string[] aidList) mastercardAid)> aidList =
            new Dictionary<string, ((string transactionType, string[] aidList) cashbackAid, (string transactionType, string[] aidList) creditAid, (string transactionType, string[] aidList) debitAid, (string transactionType, string[] aidList) mastercardAid)>()
            {
                // DEFAULT AIDS
                [CATEGORY_DEFAULT] = (CD_AID_CASHBACK, CD_AID_CREDIT, CD_AID_DEBIT, CD_AID_MASTERCARD),
                // VITAL AIDS
                [CATEGORY_VITAL] = (CV_AID_CASHBACK, CV_AID_CREDIT, CV_AID_DEBIT, CV_AID_MASTERCARD),
                // PAYMENTECH-TANDEM AIDS
                [CATEGORY_PAYMENTECH] = (CP_AID_CASHBACK, CP_AID_CREDIT, CP_AID_DEBIT, CP_AID_MASTERCARD),
                // FIRSTDATA RAPID CONNECT AIDS
                [CATEGORY_FIRSTDATA] = (CF_AID_CASHBACK, CF_AID_CREDIT, CF_AID_DEBIT, CF_AID_MASTERCARD),
                // ELAVON AIDS
                [CATEGORY_ELAVON] = (CE_AID_CASHBACK, CE_AID_CREDIT, CE_AID_DEBIT, CE_AID_MASTERCARD),
            };
    }
}
