using System;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PresentationLayer;

namespace iQuest.VendingMachine.Modules
{
    internal class CashPayment : IPaymentAlgorithm
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
            decimal insertedMoney = cashPaymentTerminal.AskForMoney();

            while (true)
            {
                if (insertedMoney < price)
                {
                    insertedMoney += cashPaymentTerminal.AskForMoney();
                }
                else if (insertedMoney >= price)
                {
                    cashPaymentTerminal.GiveBackChange(insertedMoney - price);
                    break;
                }
            }
        }
    }
}