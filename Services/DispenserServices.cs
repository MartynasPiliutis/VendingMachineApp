using VendingMachineApp.Dispensers;
using VendingMachineApp.Models;

namespace VendingMachineApp.Services
{
    internal class DispenserServices
    {
        public static void UpdateDispenser(string slotNr, int valueNumberToAmend, string newValue, string dataFile)
        {
            VmaAssign.Assign(slotNr, newValue, dataFile, valueNumberToAmend, out VmaVars.slotString, out VmaVars.valueString, out VmaVars.dataString, out VmaVars.valueNrInt);
            AdminServices.UpdateDispenserData(AdminServices.CreateAmendedList(VmaVars.slotString, VmaVars.valueString, VmaVars.dataString, VmaVars.valueNrInt), VmaVars.dataString);
        }

        public static void ShowDispenser(string dataFile)
        {
            VmaAssign.Assign(dataFile, out VmaVars.dataString);
            DispenserReports.DispenserReportToScreen(LoadDispenserInfo(VmaVars.dataString));
        }

        public static List<Dispenser> LoadDispenserInfo(string dataFile)
        {
            VmaAssign.Assign(dataFile, out VmaVars.dataString);
            List<Dispenser> dispenser = new();
            using (StreamReader reader = new(VmaVars.dataString))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split('|');
                    dispenser.Add(new DispenserSlot(values[0].ToString(), values[1].ToString(), Convert.ToDecimal(values[2]), Convert.ToInt32(values[3]), Convert.ToInt32(values[4])));
                }
            }
            return dispenser;
        }
    }
}
