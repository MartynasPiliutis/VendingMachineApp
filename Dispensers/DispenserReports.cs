using VendingMachineApp.Models;
using VendingMachineApp.Services;

namespace VendingMachineApp.Dispensers
{
    internal class DispenserReports
    {
        public static void DispenserReportToScreen(List<Dispenser> listToShow) //Shows current status of selected dispenser in Admin panel
        {
            foreach (var item in listToShow)
            {
                Console.WriteLine($"| {item.Slot} | {item.Name} | {item.Value} | {item.Counter} | {item.CounterMinimum} |");
            }
            Console.WriteLine();
        }


        public static void DispenserRoutineCheck(string dataFile) //Runs after avery change in amounts of coins or products
        {
            VmaAssign.Assign(dataFile, out VmaVars.dataString);
            List<Dispenser> dispenser = DispenserServices.LoadDispenserInfo(VmaVars.dataString);

            using StreamWriter writer = new(VmaData.warningFile, true);
            foreach (var item in dispenser)
            {
                if (item.Counter < item.CounterMinimum)
                {
                    VmaVars.warningString = $"{DateTime.Now}: {item.ReportMessage}";
                    writer.WriteLine(VmaVars.warningString);
                }
            }
            writer.Close();
        }
    }
}
