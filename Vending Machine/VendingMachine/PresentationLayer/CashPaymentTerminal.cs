using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using System;

namespace iQuest.VendingMachine.PresentationLayer
{
    public class CashPaymentTerminal
    {
        private readonly IInputOutputService ioService;

        public CashPaymentTerminal(IInputOutputService inputOutputService)
        {
            ioService = inputOutputService;
        }

        public decimal AskForMoney()
        {
            Console.WriteLine();
            ioService.Write("Please introduce money or type 'exit' to cancel: ", ConsoleColor.Cyan);

            string input = ioService.ReadLine();

            if (input == "exit")
            {
                throw new CancelException("Payment process aborted.");
            }


            if (decimal.TryParse(input, out decimal inputToDecimal))
            {
                return inputToDecimal;
            }

            return AskForMoney();
        }

        public void GiveBackChange(decimal change)
        {
            ioService.Write("Your change: " + change, ConsoleColor.Cyan);
        }

        public void ReturnInsertedMoney(decimal insertedMoney)
        {
            ioService.Write($"Please pick up your inserted money: {insertedMoney}", ConsoleColor.Cyan);
            Console.WriteLine();
        }
    }
}