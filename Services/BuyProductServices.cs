using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineApp.Dispensers;
using VendingMachineApp.Menu;
using VendingMachineApp.Models;

namespace VendingMachineApp.Services
{
    internal class BuyProductServices
    {

        public static decimal CalculateChange(decimal balance, decimal price)
        {
            VmaAssign.Assign(balance, price, out VmaVars.clientAccountDec, out VmaVars.priceDec);
            VmaVars.clientChangeDec = VmaVars.clientAccountDec - VmaVars.priceDec;
            return VmaVars.clientChangeDec;
        }

        public static void ConvertChangeToCoins(decimal clientChange)
        {
            VmaAssign.Assign(clientChange, out VmaVars.clientChangeDec);
            List<Dispenser> list = DispenserServices.LoadDispenserInfo(VmaData.moneyFile);
            VmaVars.disposableInt = list.Count;
            VmaVars.clientChangeDec = VmaVars.clientChangeDec * 100;
            for (int i = VmaVars.disposableInt - 1; i >= 0; i--)
            {
                VmaVars.coinString = list[i].Name.ToString();
                var coinInCents = list[i].Value * 100;
                VmaVars.coinsInt = Math.DivRem((int)VmaVars.clientChangeDec, (int)coinInCents, out int rem);
                if (VmaVars.coinsInt <= list[i].Counter)
                {
                    VmaVars.clientChangeDec = VmaVars.clientChangeDec - coinInCents * VmaVars.coinsInt;
                    Console.WriteLine($"{VmaVars.coinsInt} of {VmaVars.coinString} coins");
                    RemoveItemFromDispenser(list[i].Slot, VmaData.moneyFile, VmaVars.coinsInt);
                }
            }
            Console.WriteLine("\nRemaing change (if not enough coins): " + VmaVars.clientChangeDec / 100);
            DispenserReports.DispenserRoutineCheck(VmaData.moneyFile);
        }

        public static void RemoveItemFromDispenser(string slot, string dataFile, int piecesToRemove)
        {
            VmaAssign.Assign(slot, dataFile, piecesToRemove, out VmaVars.slotString, out VmaVars.dataString, out VmaVars.unitsOutInt);
            DispenserServices.UpdateDispenser(VmaVars.slotString, 3, (VmaVars.unitsOutInt * -1).ToString(), VmaVars.dataString);
        }

        public static void DeployProductAndGiveChange(string slot, string name, decimal balance, decimal price)
        {
            VmaAssign.Assign(slot, name, balance, price, out VmaVars.slotString, out VmaVars.nameString, out VmaVars.clientAccountDec, out VmaVars.priceDec);
            Console.Clear();
            VmaVars.clientChangeDec = CalculateChange(VmaVars.clientAccountDec, VmaVars.priceDec);
            RemoveItemFromDispenser(VmaVars.slotString, VmaData.productFile, 1);
            DispenserReports.DispenserRoutineCheck(VmaData.productFile);
            Console.Write(MenuStrings.strClientBuySuccessChapter1 + $"{VmaVars.nameString}\n");
            Console.Write(MenuStrings.strClientBuySuccessChapter2 + $"{VmaVars.priceDec} eur\n");
            Console.Write(MenuStrings.strClientBuySuccessChapter3 + $"{VmaVars.clientChangeDec} eur\n");
            Console.WriteLine(MenuStrings.strClientChangeInCoins + "\n");
            ConvertChangeToCoins(VmaVars.clientChangeDec);
            Console.WriteLine("\n\n" + MenuStrings.strClientBuySuccessChapter4);
            Console.WriteLine(MenuStrings.strClientBuySuccessChapter5);
            Console.WriteLine(MenuStrings.strPressAnyKey);
            Console.ReadKey();
        }
    }
}