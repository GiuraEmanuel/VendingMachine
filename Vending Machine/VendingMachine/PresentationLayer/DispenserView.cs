using iQuest.VendingMachine.Interfaces;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class DispenserView: DisplayBase, IDispenserView
    {
        public void DispenseProduct(string productName)
        {
            DisplayLine(productName, System.ConsoleColor.Green);
        }
    }
}
