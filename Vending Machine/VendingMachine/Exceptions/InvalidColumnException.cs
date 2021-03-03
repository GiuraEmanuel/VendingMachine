using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.Exceptions
{
    public class InvalidColumnException: Exception
    {
        public InvalidColumnException()
        {

        }

        public InvalidColumnException(string message) : base(message)
        {

        }

        public InvalidColumnException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
