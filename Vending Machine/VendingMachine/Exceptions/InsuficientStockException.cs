using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.Exceptions
{
    internal class InsuficientStockException: Exception
    {
        public InsuficientStockException(string message): base(message)
        {

        }

        public InsuficientStockException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
