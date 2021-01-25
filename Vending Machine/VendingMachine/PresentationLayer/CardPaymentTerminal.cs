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

        private bool CheckForValidCardNumber(string creditCardNumber)
        {
            var convertedCardNumber = Convert.ToInt32(creditCardNumber);
            for (int i = convertedCardNumber - 1; i >= 0; i-=2)
            {
               
            }
            return false;
        }
    }
}