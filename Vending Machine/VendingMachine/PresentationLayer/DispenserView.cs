namespace iQuest.VendingMachine.PresentationLayer
{
    internal class DispenserView: DisplayBase
    {
        public void DispenseProduct(string productName)
        {
            DisplayLine(productName, System.ConsoleColor.Green);
        }
    }
}
