namespace VendingMachineApp.Models
{
    //
    //Assign of pre-created variables for functios and methods
    //
    internal class VmaAssign
    {
        public static void Assign(List<string> list1, string string1, out List<string> outList1, out string outString1) { outList1 = list1; outString1 = string1; }
        public static void Assign(string string1, string string2, string string3, int int1, out string outString1, out string outString2, out string outString3, out int outInt1) { outString1 = string1; outString2 = string2; outString3 = string3; outInt1 = int1; }
        public static void Assign(string string1, string string2, int int1, out string outString1, out string outString2, out int outInt1) { outString1 = string1; outString2 = string2; outInt1 = int1; }
        public static void Assign(string string1, string string2, out string outString1, out string outString2) { outString1 = string1; outString2 = string2; }
        public static void Assign(string string1, int int1, int int2, out string outString1, out int outInt1, out int outInt2) { outString1 = string1; outInt1 = int1; outInt2 = int2; }
        public static void Assign(string string1, int int1, out string outString1, out int outInt1) { outString1 = string1; outInt1 = int1; }
        public static void Assign(string string1, string string2, decimal decimal1, decimal decimal2, out string outString1, out string outString2, out decimal outDecimal1, out decimal outDecimal2) { outString1 = string1; outString2 = string2; outDecimal1 = decimal1; outDecimal2 = decimal2; }
        public static void Assign(string string1, decimal decimal1, out string outString1, out decimal outDecimal1) { outString1 = string1; outDecimal1 = decimal1; }
        public static void Assign(string string1, out string outString1) { outString1 = string1; }
        public static void Assign(decimal decimal1, decimal decimal2, out decimal outDecimal1, out decimal outDecimal2) { outDecimal1 = decimal1; outDecimal2 = decimal2; }
        public static void Assign(decimal decimal1, out decimal outDecimal1) { outDecimal1 = decimal1; }
    }
}