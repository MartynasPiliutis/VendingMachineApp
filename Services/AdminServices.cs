using VendingMachineApp.Dispensers;
using VendingMachineApp.Menu;
using VendingMachineApp.Models;

namespace VendingMachineApp.Services
{

    public class AdminServices
    {
        public static List<string> CreateAmendedList(string slotNr, string newValue, string dataFile, int valueNumberToAmend)
        {
            VmaAssign.Assign(slotNr, newValue, dataFile, valueNumberToAmend, out VmaVars.slotString, out VmaVars.valueString, out VmaVars.dataString, out VmaVars.valueNrInt);
            VmaVars.listString = new();
            using (StreamReader reader = new(VmaVars.dataString))
            {
                while (!reader.EndOfStream)
                {
                    VmaVars.lineString = reader.ReadLine();
                    var values = VmaVars.lineString.Split('|');
                    if (values[0].ToString() == VmaVars.slotString)
                    {
                        if (VmaVars.valueNrInt == 1)
                        {
                            values[VmaVars.valueNrInt] = VmaVars.valueString;
                        }
                        if (VmaVars.valueNrInt == 2)
                        {
                            values[VmaVars.valueNrInt] = VmaVars.valueString;
                        }
                        if (VmaVars.valueNrInt == 3)
                        {
                            VmaVars.counterAmendedInt = Convert.ToInt32(values[3]) + Convert.ToInt32(VmaVars.valueString);
                            values[VmaVars.valueNrInt] = VmaVars.counterAmendedInt.ToString();
                        }
                        if (VmaVars.valueNrInt == 4)
                        {
                            values[VmaVars.valueNrInt] = VmaVars.valueString;
                        }
                    }
                    VmaVars.listString.Add($"{values[0]}|{values[1]}|{values[2]}|{values[3]}|{values[4]}");
                }
            }
            return VmaVars.listString;
        }

        public static void UpdateDispenserData(List<string> listOfData, string dataFile)
        {
            VmaAssign.Assign(listOfData, dataFile, out VmaVars.listString, out VmaVars.dataString);
            using StreamWriter writer = new(VmaVars.dataString);
            foreach (var item in VmaVars.listString)
            {
                writer.WriteLine(item);
            }
            writer.Close();
        }

        public static void AmendDispenserItems(string dataString, int dispenserIdentifier, int valueIdent)
        {
            VmaAssign.Assign(dataString, dispenserIdentifier, valueIdent, out VmaVars.dataString, out VmaVars.dispenserIdInt, out VmaVars.valueNrInt);
            Console.Write(MenuStrings.strEnterSlotNumber);
            VmaVars.slotString = Console.ReadLine().ToUpper();
            while (!MenuServices.CheckIfSlotNumberCorrect(VmaVars.slotString, VmaVars.dataString))
            {
                Console.WriteLine(MenuStrings.strInvalidSlotNumber);
                Console.Write(MenuStrings.strEnterSlotNumber);
                VmaVars.slotString = Console.ReadLine().ToUpper();
            }
            Console.Write(MenuStrings.strUnitsToAdd);
            VmaVars.unitsString = Console.ReadLine().ToUpper();
            if (valueIdent == 2)
            {
                while (!MenuServices.CheckIfNunmberIsDecimal(VmaVars.unitsString))
                {
                    Console.WriteLine(MenuStrings.strInvalidInput);
                    Console.Write(MenuStrings.strUnitsToAdd);
                    VmaVars.unitsString = Console.ReadLine();
                }
            }
            if (VmaVars.valueNrInt == 3 || VmaVars.valueNrInt == 4)
            {
                while (!MenuServices.CheckIfNunmberIsInt(VmaVars.unitsString))
                {
                    Console.WriteLine(MenuStrings.strInvalidInput);
                    Console.Write(MenuStrings.strUnitsToAdd);
                    VmaVars.unitsString = Console.ReadLine();
                }
            }

            if (VmaVars.dispenserIdInt == 1) //Money dispenser
            {
                DispenserServices.UpdateDispenser(VmaVars.slotString, VmaVars.valueNrInt, VmaVars.unitsString, VmaData.moneyFile);
                DispenserReports.DispenserRoutineCheck(VmaData.moneyFile);
            }
            if (VmaVars.dispenserIdInt == 2) //Product dispenser
            {
                DispenserServices.UpdateDispenser(VmaVars.slotString, VmaVars.valueNrInt, VmaVars.unitsString, VmaData.productFile);
                DispenserReports.DispenserRoutineCheck(VmaData.productFile);
            }
        }
    }
}