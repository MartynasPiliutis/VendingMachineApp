using VendingMachineApp.Dispensers;
using VendingMachineApp.Models;
using VendingMachineApp.Services;

namespace VendingMachineApp.Menu
{
    internal class AdminMenu
    {
        public static void CallAdminMenu()
        {
            VmaVars.selectorInt = MenuServices.MenuInputCheck(MenuStrings.strAdminMenu, 3);
            switch (VmaVars.selectorInt)
            {
                case 0:
                    MainMenu.FrontMenu();
                    break;
                case 1:
                    CallDispenserMenu(MenuStrings.strMoneyDispenserMenu, VmaData.moneyFile, VmaVars.selectorInt);
                    break;
                case 2:
                    CallDispenserMenu(MenuStrings.strProductsDispenserMenu, VmaData.productFile, VmaVars.selectorInt);
                    break;
            }

        }

        public static void CallDispenserMenu(string menuString, string data, int dispenserId)
        {
            VmaAssign.Assign(menuString, data, dispenserId, out VmaVars.menuString, out VmaVars.dataString, out VmaVars.dispenserIdInt);
            VmaVars.selectorInt = MenuServices.MenuInputCheck(VmaVars.menuString, 4);

            switch (VmaVars.selectorInt)
            {
                case 0:
                    CallAdminMenu();
                    break;

                case 1:
                    AdminServices.AmendDispenserItems(VmaVars.dataString, VmaVars.dispenserIdInt, 3);
                    CallDispenserMenu(VmaVars.menuString, VmaVars.dataString, VmaVars.dispenserIdInt);
                    break;

                case 2:
                    UpdateDispenserSlotMenu(VmaVars.dataString, VmaVars.dispenserIdInt);
                    CallDispenserMenu(VmaVars.menuString, VmaVars.dataString, VmaVars.dispenserIdInt);
                    break;

                case 3:
                    if (VmaVars.dispenserIdInt == 1) DispenserServices.ShowDispenser(VmaData.moneyFile);
                    if (VmaVars.dispenserIdInt == 2) DispenserServices.ShowDispenser(VmaData.productFile);
                    Console.Write(MenuStrings.strPressAnyKey);
                    Console.ReadKey();
                    CallDispenserMenu(VmaVars.menuString, VmaVars.dataString, VmaVars.dispenserIdInt);
                    break;
            }
        }

        public static void UpdateDispenserSlotMenu(string data, int dispenserId)
        {
            VmaAssign.Assign(data, dispenserId, out VmaVars.dataString, out VmaVars.dispenserIdInt);
            if (VmaVars.dispenserIdInt == 1) //Money dispenser
            {
                VmaVars.menuString = MenuStrings.strMoneyDispenserUpdate;
                VmaVars.caseIdInt = MenuServices.MenuInputCheck(VmaVars.menuString, 4);
                VmaVars.caseIdInt = Convert.ToInt32($"{VmaVars.dispenserIdInt}{VmaVars.caseIdInt}");
            }
            if (VmaVars.dispenserIdInt == 2) //Product Dispenser
            {
                VmaVars.menuString = MenuStrings.strProductsDispenserUpdate;
                VmaVars.caseIdInt = MenuServices.MenuInputCheck(VmaVars.menuString, 4);
                VmaVars.caseIdInt = Convert.ToInt32($"{VmaVars.dispenserIdInt}{VmaVars.caseIdInt}");
            }
            switch (VmaVars.caseIdInt)
            {
                case 0:
                    CallAdminMenu();
                    break;
                case 10:
                    CallDispenserMenu(MenuStrings.strMoneyDispenserMenu, VmaVars.dataString, VmaVars.dispenserIdInt);
                    break;
                case 20:
                    CallDispenserMenu(MenuStrings.strProductsDispenserMenu, VmaVars.dataString, VmaVars.dispenserIdInt);
                    break;
                case 11:
                    AdminServices.AmendDispenserItems(VmaVars.dataString, VmaVars.dispenserIdInt, 1);
                    UpdateDispenserSlotMenu(VmaVars.dataString, VmaVars.dispenserIdInt);
                    break;
                case 12:
                    AdminServices.AmendDispenserItems(VmaVars.dataString, VmaVars.dispenserIdInt, 4);
                    UpdateDispenserSlotMenu(VmaVars.dataString, VmaVars.dispenserIdInt);
                    break;
                case 13:
                    DispenserServices.ShowDispenser(VmaData.moneyFile);
                    Console.Write(MenuStrings.strPressAnyKey);
                    Console.ReadKey();
                    UpdateDispenserSlotMenu(VmaVars.dataString, VmaVars.dispenserIdInt);
                    break;
                case 21:
                    AdminServices.AmendDispenserItems(VmaVars.dataString, VmaVars.dispenserIdInt, 1);
                    UpdateDispenserSlotMenu(VmaVars.dataString, VmaVars.dispenserIdInt);
                    break;
                case 22:
                    AdminServices.AmendDispenserItems(data, VmaVars.dispenserIdInt, 2);
                    UpdateDispenserSlotMenu(VmaVars.dataString, VmaVars.dispenserIdInt);
                    break;
                case 23:
                    AdminServices.AmendDispenserItems(VmaVars.dataString, VmaVars.dispenserIdInt, 4);
                    UpdateDispenserSlotMenu(VmaVars.dataString, VmaVars.dispenserIdInt);
                    break;
                case 24:
                    DispenserServices.ShowDispenser(VmaData.productFile);
                    Console.Write(MenuStrings.strPressAnyKey);
                    Console.ReadKey();
                    UpdateDispenserSlotMenu(VmaVars.dataString, VmaVars.dispenserIdInt);
                    break;
            }
        }
    }
}
