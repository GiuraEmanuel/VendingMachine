using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PresentationLayer;

namespace iQuest.VendingMachine.Modules
{
    public class CashPayment : IPaymentAlgorithm
    {
        public string Name => "Cash";
        public int Id { get; }

        private readonly CashPaymentTerminal cashPaymentTerminal;

        public CashPayment(int id)
        {
            Id = id;
            cashPaymentTerminal = new CashPaymentTerminal();
        }

        public void Run(decimal price)
        {
            decimal insertedMoney = 0;
            try
            {
                insertedMoney = cashPaymentTerminal.AskForMoney();
                while (insertedMoney < price)
                {
                    insertedMoney += cashPaymentTerminal.AskForMoney();
                }

                cashPaymentTerminal.GiveBackChange(insertedMoney - price);
            }
            catch (CancelException exception)
            {
                if (insertedMoney > 0)
                {
                    cashPaymentTerminal.ReturnInsertedMoney(insertedMoney);
                }

                throw exception;
            }
        }
    }
}