using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.Interfaces
{
    public interface IPaymentMethodProcessor
    {
        public List<IPaymentAlgorithm> GetAllPaymentMethods();
        public IPaymentAlgorithm GetPaymentMethod(int id);
    }
}
