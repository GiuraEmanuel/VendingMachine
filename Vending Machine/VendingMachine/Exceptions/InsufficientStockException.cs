using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.Exceptions
{
    internal class InsufficientStockException: Exception
    {
        public InsufficientStockException()
        {

        }

        public InsufficientStockException(string message): base(message)
        {

        }

        public InsufficientStockException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
