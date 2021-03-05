using System.Collections.Generic;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Modules;

namespace iQuest.VendingMachine.Repository
{
    public class PaymentMethodProcessor : IPaymentMethodProcessor
    {
        private readonly IInputOutputService ioService;

        private readonly List<IPaymentAlgorithm> paymentMethods;

        public PaymentMethodProcessor(IInputOutputService inputOutputService)
        {
            ioService = inputOutputService;
            paymentMethods = new List<IPaymentAlgorithm>
                {
                new CashPayment(1,ioService),
                new CardPayment(2,ioService)
                };
        }

        public List<IPaymentAlgorithm> GetAllPaymentMethods()
        {
            return paymentMethods;
        }

        public IPaymentAlgorithm GetPaymentMethod(int id) => paymentMethods.Find(paymentMethods => paymentMethods.Id == id);
    }
}
