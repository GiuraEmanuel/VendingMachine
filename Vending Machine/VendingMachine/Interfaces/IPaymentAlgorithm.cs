using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.Interfaces
{
    internal interface IPaymentAlgorithm
    {
        public string Name { get;}

        public int Id { get; }

        public void Run(decimal price);
    }
}
