using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PresentationLayer;

namespace iQuest.VendingMachine.Modules
{
    public class CashPayment : IPaymentAlgorithm
    {
        public string Name => "cash";

        private readonly CashPaymentTerminal cashPayment;

        private readonly Product product;

        public CashPayment()
        {
            cashPayment = new CashPaymentTerminal();
            product = new Product();
        }

        public void Run(decimal price)
        {
            decimal insertedMoney = cashPayment.AskForMoney();

            if (insertedMoney > product.Price)
            {
                cashPayment.GiveBackChange();
            }
        }
    }
}
