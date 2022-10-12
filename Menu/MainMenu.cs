using VendingMachineApp.Models;
using VendingMachineApp.Services;

namespace VendingMachineApp.Menu
{
    internal class MainMenu
    {
        public static void FrontMenu()
        {
            Console.Clear();
            VmaVars.selectorInt = MenuServices.MenuInputCheck(MenuStrings.strMainMenu, 3);
            switch (VmaVars.selectorInt)
            {
                case 1:
                    AdminMenu.CallAdminMenu();
                    break;
                case 2:
                    ClientMenu.CallClientMainMenu();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
