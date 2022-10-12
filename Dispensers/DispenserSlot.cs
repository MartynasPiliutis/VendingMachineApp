namespace VendingMachineApp.Dispensers
{
    internal class DispenserSlot : Dispenser
    {
        public DispenserSlot(string slot, string name, decimal value, int counter, int counterMinimum) : base(slot, name, value, counter, counterMinimum)
        {
        }
    }
}
