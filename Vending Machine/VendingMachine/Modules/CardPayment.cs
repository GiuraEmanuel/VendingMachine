using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PresentationLayer;

namespace iQuest.VendingMachine.Modules
{
    public class CardPayment : IPaymentAlgorithm
    {
        private readonly CardPaymentTerminal cardPaymentTerminal;

        public string Name => "Card";

        public int Id { get; }


        public CardPayment(int id)
        {
            Id = id;
            cardPaymentTerminal = new CardPaymentTerminal();
        }

        public void Run(decimal price)
        {
            cardPaymentTerminal.AskForCardNumber();
        }
    }
}
