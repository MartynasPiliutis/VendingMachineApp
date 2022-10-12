namespace VendingMachineApp.Dispensers
{
    internal abstract class Dispenser
    {
        public string Slot { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int Counter { get; set; }
        public int CounterMinimum { get; set; }
        public string ReportMessage { get; set; }
        protected Dispenser(string slot, string name, decimal value, int counter, int counterMinimum)
        {
            this.Slot = slot;
            this.Name = name;
            this.Value = value;
            this.Counter = counter;
            this.CounterMinimum = counterMinimum;
            ReportMessage = $"There are {this.Counter} units left of ---{this.Name}--- on slot number {this.Slot}.";

            //ReportMessage is for reporting when vending mashine is low on individual coins or products.
            //Warning recorded to warning.csv when Counter is lower than CounerMinimum
        }
    }
}
