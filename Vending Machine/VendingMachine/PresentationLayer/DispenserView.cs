using System;
using iQuest.VendingMachine.Interfaces;

namespace iQuest.VendingMachine.PresentationLayer
{
    public class DispenserView: IDispenserView
    {
        private readonly DisplayBase displayBase;

        public DispenserView()
        {
            displayBase = new DisplayBase();
        }

        public void DispenseProduct(string productName)
        {
            Console.WriteLine("Your product is being dispensed: ");
            displayBase.DisplayLine(productName, ConsoleColor.Green);
        }
    }
}
