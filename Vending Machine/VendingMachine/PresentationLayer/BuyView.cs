using System;
using System.Collections.Generic;
using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Modules;
using iQuest.VendingMachine.Repository;

namespace iQuest.VendingMachine.PresentationLayer
{
    public class BuyView : IBuyView
    {
        private readonly ProductRepository productRepository;

        private readonly DisplayBase displayBase;

        public BuyView()
        {
            displayBase = new DisplayBase();
            productRepository = new ProductRepository();
        }

        public Product RequestProduct(int columnId)
        {
            var product = productRepository.GetByColumn(columnId);
            if (product == null)
            {
                throw new InvalidColumnException("Product does not exist.");
            }

            if (product.Quantity <= 0)
            {
                throw new InsufficientStockException("Insufficient stock.");
            }

            if (product == null)
            {
                throw new InvalidColumnException("Product does not exist.");
            }

            return product;
        }

        public int AskForColumnId()
        {
            Console.WriteLine();
            displayBase.Display("Enter product id: ", ConsoleColor.Cyan);
            string input = displayBase.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new CancelException("Buy process aborted.");
            }

            if (int.TryParse(input, out int columnId))
            {
                return columnId;
            }

            throw new InvalidColumnException("Invalid product id.");
        }

        public int AskForPaymentMethod(List<IPaymentAlgorithm> paymentMethods)
        {
            Console.WriteLine();
            displayBase.Display("Select payment method or type 'exit' to abort:", ConsoleColor.Cyan);
            Console.WriteLine();

            foreach (var paymentMethod in paymentMethods)
            {
                displayBase.DisplayLine($"{paymentMethod.Id} - {paymentMethod.Name}", ConsoleColor.Cyan);
            }

            var input = displayBase.ReadLine();

            if (input == "exit")
            {
                throw new CancelException("Payment process aborted.");
            }

            foreach (var paymentMethod in paymentMethods)
            {
                if (paymentMethod.Id == Convert.ToInt32(input))
                {
                    return paymentMethod.Id;
                }
            }

            displayBase.Display("Invalid payment method selected.",ConsoleColor.Red);

            return AskForPaymentMethod(paymentMethods);
        }

        public void ShowError(string errorMessage)
        {
            displayBase.Display(errorMessage, ConsoleColor.Red);
        }
    }
}