using VendingMachineApp.Dispensers;
using VendingMachineApp.Models;

namespace VendingMachineApp.Services
{
    internal class ClientServices
    {
        //
        //Cute table of product to show for client :)
        //
        public static void ShowProductsToClient(List<Dispenser> dispenser, int posX)
        {
            int r = 3;
            int c = Console.CursorLeft + posX;
            Console.Clear();
            Console.SetCursorPosition(c, 0);
            Console.WriteLine($" ____________________________________________ ");
            Console.SetCursorPosition(c, 1);
            Console.WriteLine($"| SLOT |   PRODUCT   | AVAILABLE |   PRICE   |");
            Console.SetCursorPosition(c, 2);
            Console.WriteLine($"|------|-------------|-----------|-----------|");

            foreach (var item in dispenser)
            {
                Console.SetCursorPosition(c, r);
                Console.Write($"| {item.Slot}");
                Console.SetCursorPosition(c + 7, r);
                Console.Write($"| {item.Name}");
                Console.SetCursorPosition(c + 21, r);
                Console.Write($"|    {item.Counter}");
                Console.SetCursorPosition(c + 33, r);
                Console.Write($"| {item.Value} eur");
                Console.SetCursorPosition(c + 45, r);
                Console.Write($"|");
                r++;
            }
            Console.WriteLine();
            Console.SetCursorPosition(c, r);
            Console.WriteLine($"*------*-------------*-----------*-----------*");
        }

        public static void GetSelectedItemValueAndName(string dataFile, string slot, out decimal price, out string? name)
        {
            VmaAssign.Assign(dataFile, slot, out VmaVars.dataString, out VmaVars.slotString);
            List<Dispenser> list = DispenserServices.LoadDispenserInfo(VmaVars.dataString);
            foreach (var item in list)
            {
                if (item.Slot == VmaVars.slotString)
                {
                    VmaVars.priceDec = item.Value;
                    VmaVars.valueString = item.Name;
                }
            }
            price = VmaVars.priceDec;
            name = VmaVars.valueString;
        }

        public static bool CheckIfMoneyEnough(decimal balance, decimal price)
        {
            VmaAssign.Assign(balance, price, out VmaVars.clientAccountDec, out VmaVars.priceDec);
            if (VmaVars.clientAccountDec >= VmaVars.priceDec) return true; else return false;
        }
    }
}
