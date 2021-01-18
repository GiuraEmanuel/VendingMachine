using System;
using iQuest.VendingMachine.Exceptions;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class CardPaymentTerminal : DisplayBase
    {
        public string AskForCardNumber()
        {
            Console.WriteLine();
            DisplayLine("Input your credit card number: ", ConsoleColor.Cyan);

            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new InvalidInputException("Credit card number must be introduced.");
            }

            if (input.Length == 16)
            {
                return input;
            }

            throw new InvalidInputException("Invalid credit card number introduced.");
        }
    }
}