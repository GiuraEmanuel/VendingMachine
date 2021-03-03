using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.Interfaces
{
    public interface IPaymentMethodsRepository
    {
        public List<IPaymentAlgorithm> GetAllPaymentMethods();
        public IPaymentAlgorithm GetPaymentMethod(int id);
    }
}
