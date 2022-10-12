using VendingMachineApp.Models;
using VendingMachineApp.Services;

namespace VendingMachineApp.Menu
{
    internal class ClientMenu
    {
        public static void CallClientMainMenu()
        {
            VmaVars.selectorInt = MenuServices.MenuInputCheck(MenuStrings.strClientMenu, 3);
            switch (VmaVars.selectorInt)
            {
                case 0:
                    MainMenu.FrontMenu();
                    break;
                case 1:
                    ClientServices.ShowProductsToClient(DispenserServices.LoadDispenserInfo(VmaData.productFile), 40);
                    Console.Write(MenuStrings.strPressAnyKey);
                    Console.ReadKey();
                    CallClientMainMenu();
                    break;
                case 2:
                    CallClientBuyMenuI(0);
                    break;
            }
        }
        public static void CallClientBuyMenuI(decimal clientAccount)
        {
            VmaAssign.Assign(clientAccount, out VmaVars.clientAccountDec);
            VmaVars.inputString = MenuServices.BuyMenu1InputCheck(MenuStrings.strClientBuyInsertMoney);
            if (VmaVars.inputString == "R")
            {
                if (VmaVars.clientAccountDec != 0)
                {
                    Console.WriteLine(MenuStrings.strClientCashReturn + $"{VmaVars.clientAccountDec} eur");
                    Console.Write(MenuStrings.strPressAnyKey);
                    Console.ReadKey();
                }
                CallClientMainMenu();
            }
            else
            {
                VmaVars.clientAccountDec = VmaVars.clientAccountDec + Convert.ToDecimal(VmaVars.inputString);
                CallClientBuyMenuII(VmaVars.clientAccountDec);
            }
        }

        public static void CallClientBuyMenuII(decimal clientAccount)
        {
            VmaAssign.Assign(clientAccount, out VmaVars.clientAccountDec);
            VmaVars.inputString = MenuServices.BuyMenu2InputCheck(MenuStrings.strClientBuySelectSlot, VmaVars.clientAccountDec);
            if (VmaVars.inputString == "R")
            {
                Console.WriteLine(MenuStrings.strClientCashReturn + $"{VmaVars.clientAccountDec} eur");
                Console.Write(MenuStrings.strPressAnyKey);
                Console.ReadKey();
                CallClientMainMenu();
            }
            else if (VmaVars.inputString == "C")
            {
                CallClientBuyMenuI(VmaVars.clientAccountDec);
            }
            else
            {
                ClientServices.GetSelectedItemValueAndName(VmaData.productFile, VmaVars.inputString, out VmaVars.priceDec, out VmaVars.valueString);
                if (!ClientServices.CheckIfMoneyEnough(VmaVars.clientAccountDec, VmaVars.priceDec))
                {
                    Console.WriteLine(MenuStrings.strClientBuyNotEnoughMoney);
                    Console.WriteLine($"Item price: {VmaVars.priceDec} eur\nYour balance: {VmaVars.clientAccountDec}\n");
                    Console.WriteLine(MenuStrings.strPressAnyKey);
                    Console.ReadKey();
                    CallClientBuyMenuII(VmaVars.clientAccountDec);
                }
                else
                {
                    BuyProductServices.DeployProductAndGiveChange(VmaVars.slotString, VmaVars.valueString, VmaVars.clientAccountDec, VmaVars.priceDec);
                    CallClientMainMenu();
                }
            }

        }
    }
}
