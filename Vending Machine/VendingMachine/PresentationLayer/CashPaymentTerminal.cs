using System;
using System.Linq;
using System.Text.RegularExpressions;
using iQuest.VendingMachine.Exceptions;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class CashPaymentTerminal : DisplayBase
    {
        public decimal AskForMoney()
        {
            Console.WriteLine();
            Display("Please introduce money: ", ConsoleColor.Cyan);

            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new CancelException("Payment process aborted.");
            }


            decimal inputToDecimal = Convert.ToDecimal(input);

            return inputToDecimal;
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