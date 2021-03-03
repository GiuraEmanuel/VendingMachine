using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.Exceptions
{
    public class InvalidPaymentMethodException : Exception
    {
        public InvalidPaymentMethodException()
        {
                
        }

        public InvalidPaymentMethodException(string message): base(message)
        {
                
        }

        public InvalidPaymentMethodException(string message, Exception inner) : base(message, inner)
        {
                
        }
    }
}
