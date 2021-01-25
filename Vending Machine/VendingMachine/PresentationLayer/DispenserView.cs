using System;
using iQuest.VendingMachine.Interfaces;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class DispenserView: DisplayBase, IDispenserView
    {
        public void DispenseProduct(string productName)
        {
            Console.WriteLine("Your product is being dispensed: ");
            DisplayLine(productName, System.ConsoleColor.Green);
        }
    }
}
