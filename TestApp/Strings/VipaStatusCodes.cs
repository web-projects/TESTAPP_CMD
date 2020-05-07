using static System.ExtensionMethods;

namespace TestApp.Strings
{
    public enum VipaSW1SW2Codes
    {
        [StringValue("Command success")]
        Success = 0x9000,
        [StringValue("File not found or not accessible")]
        FileNotFoundOrNotAccessible = 0x9f13,
        [StringValue("Invalid data")]
        InvalidData = 0x9f21,
        [StringValue("Contactless transaction failed")]
        CLessTransactionFail = 0x9f33,
        [StringValue("Contactless card in field")]
        CLessCardInField = 0x9f36,
        [StringValue("Command cancelled")]
        CommandCancelled = 0x9f41,
        [StringValue("User entry cancelled")]
        UserEntryCancelled = 0x9f43,
        [StringValue("Failure")]
        Failure = 0xFFFF
    }
}
