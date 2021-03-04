using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PresentationLayer;

namespace iQuest.VendingMachine.Modules
{
    public class CardPayment : IPaymentAlgorithm
    {
        private readonly CardPaymentTerminal cardPaymentTerminal;

        private readonly IInputOutputService ioService;

        public string Name => "Card";

        public int Id { get; }


        public CardPayment(int id, IInputOutputService inputOutputService)
        {
            ioService = inputOutputService;
            Id = id;
            cardPaymentTerminal = new CardPaymentTerminal(ioService);
        }

        public void Run(decimal price)
        {
            cardPaymentTerminal.AskForCardNumber();
        }
    }
}