using System;
using System.Collections.Generic;
using System.Text;
using iQuest.VendingMachine.Modules;

namespace iQuest.VendingMachine.Interfaces
{
    internal interface IBuyView
    {
        Product RequestProduct(int columnId);
        int AskForColumnId();
        public void ShowError(string errorMessage);
        public int AskForPaymentMethod(List<IPaymentAlgorithm> paymentMethods);
    }
}
