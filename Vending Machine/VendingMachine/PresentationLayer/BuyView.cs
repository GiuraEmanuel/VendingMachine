using System;
using System.Collections.Generic;
using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Modules;
using iQuest.VendingMachine.Repository;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class BuyView : DisplayBase, IBuyView
    {
        private readonly ProductRepository productRepository = new ProductRepository();

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
            Display("Enter product id: ", ConsoleColor.Cyan);
            string input = Console.ReadLine();

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

        public int AskForPaymentMethod(List<PaymentMethod> paymentMethods)
        {
            Console.WriteLine();
            Display("Select payment method:", ConsoleColor.Cyan);
            Console.WriteLine("1.Cash");
            Console.WriteLine("2.Card");

            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new CancelException("Pay process aborted.");
            }

            foreach (var paymentMethod in paymentMethods)
            {
                if (paymentMethod.Id == Convert.ToInt32(input))
                {
                    return paymentMethod.Id;
                }
            }
            throw new InvalidPaymentMethodException("Invalid payment method selected");
        }

        public void ShowError(string errorMessage)
        {
            Display(errorMessage, ConsoleColor.Red);
        }
    }
}