using System;
using iQuest.VendingMachine.Interfaces;

namespace iQuest.VendingMachine.PresentationLayer
{
    public class DispenserView
    {
        private readonly IInputOutputService ioService;

        public DispenserView(IInputOutputService inputOutputService)
        {
            ioService = inputOutputService;
        }

        public void DispenseProduct(string productName)
        {
            Console.WriteLine("Your product is being dispensed: ");
            ioService.WriteLine(productName, ConsoleColor.Blue);
        }
    }
}
