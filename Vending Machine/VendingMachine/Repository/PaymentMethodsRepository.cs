using System.Collections.Generic;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Modules;

namespace iQuest.VendingMachine.Repository
{
    public class PaymentMethodsRepository : IPaymentMethodsRepository
    {
        private readonly List<IPaymentAlgorithm> paymentMethods = new List<IPaymentAlgorithm>
        {
            new CashPayment(1),
            new CardPayment(2)
        };

        public List<IPaymentAlgorithm> GetAllPaymentMethods()
        {
            return paymentMethods;
        }

        public IPaymentAlgorithm GetPaymentMethod(int id) => paymentMethods.Find(paymentMethods => paymentMethods.Id == id);
    }
}
