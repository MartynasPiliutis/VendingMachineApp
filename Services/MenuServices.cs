using VendingMachineApp.Menu;
using VendingMachineApp.Models;

namespace VendingMachineApp.Services
{
    internal class MenuServices
    {
        public static bool CheckIfSlotNumberCorrect(string slotNr, string dataFile)
        {
            VmaAssign.Assign(slotNr, dataFile, out VmaVars.slotString, out VmaVars.dataString);
            using StreamReader reader = new(VmaVars.dataString);
            while (!reader.EndOfStream)
            {
                VmaVars.lineString = reader.ReadLine();
                var values = VmaVars.lineString.Split('|');
                if (values[0].ToString() == VmaVars.slotString)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool CheckIfNunmberIsInt(string input)
        {
            VmaAssign.Assign(input, out VmaVars.inputString);
            _ = int.TryParse(VmaVars.inputString, out VmaVars.outputInt);
            if (VmaVars.outputInt == 0)
            {
                return false;
            }
            else return true;
        }

        public static bool CheckIfNunmberIsDecimal(string input)
        {
            VmaAssign.Assign(input, out VmaVars.inputString);
            _ = decimal.TryParse(VmaVars.inputString, out VmaVars.outputDec);
            if (VmaVars.outputDec == 0)
            {
                return false;
            }
            else return true;
        }

        public static int MenuInputCheck(string menu, int reps)
        {
            VmaAssign.Assign(menu, reps, out VmaVars.menuString, out VmaVars.cyclesInt);
            Console.Clear();
            Console.Write(VmaVars.menuString);
            VmaVars.inputString = Console.ReadKey().KeyChar.ToString();
            Console.WriteLine();
            VmaVars.okBool = false;
            while (VmaVars.okBool == false)
            {
                for (int i = 0; i < VmaVars.cyclesInt; i++)
                {
                    if (VmaVars.inputString == i.ToString())
                    {
                        VmaVars.okBool = true;
                        return Convert.ToInt32(VmaVars.inputString);
                    }
                }
                Console.Write(MenuStrings.strInvalidMenuInput);
                VmaVars.inputString = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine();
            }
            return Convert.ToInt32(VmaVars.inputString);
        }

        public static string BuyMenu1InputCheck(string menu)
        {
            VmaAssign.Assign(menu, out VmaVars.menuString);
            Console.Clear();
            Console.Write(VmaVars.menuString);
            VmaVars.inputString = Console.ReadLine().ToUpper();
            VmaVars.inputString = VmaVars.inputString.Replace(",", ".");
            Console.WriteLine();
            while (VmaVars.inputString != "R" && !CheckIfNunmberIsDecimal(VmaVars.inputString))
            {
                Console.Write(MenuStrings.strInvalidMenuInput);
                VmaVars.inputString = Console.ReadLine().ToUpper();
                VmaVars.inputString = VmaVars.inputString.Replace(",", ".");
                Console.WriteLine();
            }
            return VmaVars.inputString;
        }

        public static string BuyMenu2InputCheck(string menu, decimal clientAccount)
        {
            VmaAssign.Assign(menu, clientAccount, out VmaVars.menuString, out VmaVars.clientAccountDec);
            Console.Clear();
            ClientServices.ShowProductsToClient(DispenserServices.LoadDispenserInfo(VmaData.productFile), 80);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(MenuStrings.strClientAccount + $"{VmaVars.clientAccountDec}\n\n");
            Console.Write(VmaVars.menuString);
            VmaVars.inputString = Console.ReadLine().ToUpper();
            Console.WriteLine();
            while (VmaVars.inputString != "R" && VmaVars.inputString != "C" && !CheckIfSlotNumberCorrect(VmaVars.inputString, VmaData.productFile))
            {
                Console.Write(MenuStrings.strInvalidMenuInput);
                VmaVars.inputString = Console.ReadLine().ToUpper();
                Console.WriteLine();
            }
            return VmaVars.inputString;
        }
    }
}
