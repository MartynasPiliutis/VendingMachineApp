namespace VendingMachineApp.Menu
{
    //
    //Strings are used for menu dialogs. Code looks lighter when its not flooded with string lines
    //
    internal class MenuStrings
    {
        public static readonly string strMainMenu = "------- MAIN MENU -------\n\n[1] - Open Admin Panel\n[2] - Open Customer Panel\n[0] - EXIT\n\nEnter menu number: ";
        public static readonly string strAdminMenu = "------- ADMIN MENU -------\n\n[1] - Money Dispenser\n[2] - Products Dispenser\n[0] - MAIN MENU\n\nEnter menu number: ";
        public static readonly string strInvalidMenuInput = "Input is invalid. Please try again.\nEnter menu number: ";
        public static readonly string strInvalidSlotNumber = "Invalid slot number. Please try again.";
        public static readonly string strInvalidInput = "Invalid input. Please try again.";
        public static readonly string strMoneyDispenserMenu = "---- MONEY DISPENSER ----\n\n[1] - Add money to dispenser\n[2] - Change dispenser values\n[3] - Show money dispenser data\n[0] - ADMIN MENU\n\nEnter menu number: ";
        public static readonly string strProductsDispenserMenu = "------ PRODUCTS DISPENSER ------\n\n[1] - Add products to dispenser\n[2] - Change dispenser values\n[3] - Show products dispenser data\n[0] - ADMIN MENU\n\nEnter menu number: ";
        public static readonly string strPressAnyKey = "Press any key to continue...";
        public static readonly string strEnterSlotNumber = "Enter required slot number: ";
        public static readonly string strUnitsToAdd = "Enter required value: ";
        public static readonly string strMoneyDispenserUpdate = "---- MONEY DISPENSER CONFIG ----\n\n[1] - Change item name\n[2] - Change minimum quantity alert\n[3] - Show money dispenser data\n[0] - MONEY DISPENSER MENU\n\nEnter menu number: ";
        public static readonly string strProductsDispenserUpdate = "---- PRODUCTS DISPENSER CONFIG ----\n\n[1] - Change item name\n[2] - Change item price\n[3] - Change minimum quantity alert\n[4] - Show products dispenser data\n[0] - PRODUCTS DISPENSER MENU\n\nEnter menu number: ";
        public static readonly string strClientMenu = "------- CLIENT MAIN MENU -------\n\n[1] - Review Production\n[2] - Buy production\n[0] - MAIN MENU\n\nEnter menu number: ";
        public static readonly string strClientBuyInsertMoney = "------- BUY MENU I -------\n\nInsert money and continue\n[R] - RETURN MONEY AND QUIT\n\nInput: ";
        public static readonly string strClientBuySelectSlot = "------- BUY MENU II -------\n\nSelect item slot\n[C] - Add money to account\n[R] - RETURN MONEY AND QUIT\n\nInput: ";
        public static readonly string strClientBuyNotEnoughMoney = "------- FAIL!!! -------\n\nNot enough money in your account!\nAdd money or select another product.";
        public static readonly string strClientBuySuccessChapter1 = "------- SUCCESS!!! -------\n\nYou bought: ";
        public static readonly string strClientBuySuccessChapter2 = "You paid: ";
        public static readonly string strClientBuySuccessChapter3 = "Your change: ";
        public static readonly string strClientBuySuccessChapter4 = "Please take your product and enjoy :)";
        public static readonly string strClientBuySuccessChapter5 = "Thank You for buying. Bye!";
        public static readonly string strClientCashReturn = "Cash returned: ";
        public static readonly string strClientAccount = "Your Account: ";
        public static readonly string strClientChangeInCoins = "Please take your change!";
    }
}
