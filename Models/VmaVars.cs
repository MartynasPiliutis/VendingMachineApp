namespace VendingMachineApp.Models
{
    //
    //Re-using alredy created variables decreses memory loads when new are created with every function or method
    //
    public static class VmaVars
    {
        public static List<string>? listString;
        public static string? coinString;
        public static string? dataString;
        public static string? inputString;
        public static string? menuString;
        public static string? nameString;
        public static string? lineString;
        public static string? slotString;
        public static string? unitsString;
        public static string? valueString;
        public static string? warningString;
        public static int caseIdInt;
        public static int coinsInt;
        public static int cyclesInt;
        public static int counterAmendedInt;
        public static int dispenserIdInt;
        public static int disposableInt;
        public static int outputInt;
        public static int selectorInt;
        public static int unitsOutInt;
        public static int valueNrInt;
        public static decimal outputDec;
        public static decimal clientAccountDec;
        public static decimal clientChangeDec;
        public static decimal priceDec;
        public static bool okBool;
    }
}
