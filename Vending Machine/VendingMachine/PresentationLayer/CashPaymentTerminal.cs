using System;
using System.ComponentModel;
using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Repository;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class CashPaymentTerminal : DisplayBase
    {
        public decimal AskForMoney()
        {
            Console.WriteLine();
            Display("Please introduce money", ConsoleColor.Cyan);

            string input = Console.ReadLine();

            decimal decimalOutput = Convert.ToDecimal(input);

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new InvalidInputException("Invalid input.");
            }

            return decimalOutput;
        }

        public void GiveBackChange()
        {
            decimal result = 

        }
    }
}