using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PresentationLayer;

namespace iQuest.VendingMachine.Modules
{
    public class CardPayment : IPaymentAlgorithm
    {
        private readonly CardPaymentTerminal cardPaymentTerminal;

        public string Name => "card";


        public CardPayment()
        {
            cardPaymentTerminal = new CardPaymentTerminal();
        }

        public void Run(decimal price)
        {
            cardPaymentTerminal.AskForCardNumber();
        }
    }
}
