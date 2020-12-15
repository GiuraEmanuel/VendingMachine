using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.Exceptions
{
    internal class CancelException : Exception
    {
        public CancelException(string message): base(message)
        {

        }

        public CancelException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
