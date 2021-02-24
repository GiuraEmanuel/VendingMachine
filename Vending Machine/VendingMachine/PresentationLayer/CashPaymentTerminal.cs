using System;
using iQuest.VendingMachine.Exceptions;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class CashPaymentTerminal : DisplayBase
    {
        public decimal AskForMoney()
        {
            Console.WriteLine();
            Display("Please introduce money or type 'exit' to cancel: ", ConsoleColor.Cyan);

            string input = Console.ReadLine();

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
            Display("Your change: " + change, ConsoleColor.Cyan);
            Console.WriteLine();
        }

        public void ReturnInsertedMoney(decimal insertedMoney)
        {
            Display($"Please pick up your inserted money: {insertedMoney}", ConsoleColor.Cyan);
            Console.WriteLine();
        }
    }
}