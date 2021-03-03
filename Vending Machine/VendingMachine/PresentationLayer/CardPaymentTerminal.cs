﻿using System;
using iQuest.VendingMachine.Exceptions;

namespace iQuest.VendingMachine.PresentationLayer
{
    public class CardPaymentTerminal
    {
        private readonly DisplayBase displayBase;

        public CardPaymentTerminal()
        {
            displayBase = new DisplayBase();
        }

        public string AskForCardNumber()
        {
            Console.WriteLine();
            displayBase.DisplayLine("Please input your credit card number or type 'exit' to cancel: ", ConsoleColor.Cyan);

            var creditCardNumber = displayBase.ReadLine();

            if (creditCardNumber == "exit")
            {
                throw new CancelException("Payment process aborted.");
            }

            if (creditCardNumber.Length > 16 || creditCardNumber.Length < 16 ||
                string.IsNullOrEmpty(creditCardNumber) || !CheckForValidCardNumber(creditCardNumber))
            {
                Console.WriteLine("Invalid credit card number introduced.");
            }

            if (creditCardNumber.Length == 16 && CheckForValidCardNumber(creditCardNumber))
            {
                return creditCardNumber;
            }

            return AskForCardNumber();
        }

        private bool CheckForValidCardNumber(string creditCardNumber)
        {
            int nDigits = creditCardNumber.Length;

            int nSum = 0;
            bool isSecond = false;
            for (int i = nDigits - 1; i >= 0; i--)
            {
                int d = creditCardNumber[i] - '0';

                if (isSecond)
                    d *= 2;

                nSum += d / 10;
                nSum += d % 10;

                isSecond = !isSecond;
            }

            return (nSum % 10 == 0);
        }
    }
}