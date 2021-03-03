using System;
using iQuest.VendingMachine.Exceptions;

namespace iQuest.VendingMachine.PresentationLayer
{
    public class CashPaymentTerminal
    {
        private readonly DisplayBase displayBase;

        public CashPaymentTerminal()
        {
            displayBase = new DisplayBase();
        }

        public decimal AskForMoney()
        {
            Console.WriteLine();
            displayBase.Display("Please introduce money or type 'exit' to cancel: ", ConsoleColor.Cyan);

            string input = displayBase.ReadLine();

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
            displayBase.Display("Your change: " + change, ConsoleColor.Cyan);
            Console.WriteLine();
        }

        public void ReturnInsertedMoney(decimal insertedMoney)
        {
            displayBase.Display($"Please pick up your inserted money: {insertedMoney}", ConsoleColor.Cyan);
            Console.WriteLine();
        }
    }
}