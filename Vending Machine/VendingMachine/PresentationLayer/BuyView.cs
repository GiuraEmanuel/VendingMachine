using System;
using System.Collections.Generic;
using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Modules;
using iQuest.VendingMachine.Repository;

namespace iQuest.VendingMachine.PresentationLayer
{
    public class BuyView
    {
        private readonly ProductRepository productRepository;

        private readonly IInputOutputService ioService;

        public BuyView(IInputOutputService inputOutputService)
        {
            ioService = inputOutputService;
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
            ioService.Write("Enter product id: ", ConsoleColor.Cyan);
            string input = ioService.ReadLine();

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
            ioService.Write("Select payment method or type 'exit' to abort:", ConsoleColor.Cyan);

            foreach (var paymentMethod in paymentMethods)
            {
                ioService.WriteLine($"{paymentMethod.Id} - {paymentMethod.Name}", ConsoleColor.Cyan);
            }

            Console.WriteLine();

            var input = ioService.ReadLine();

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

            ioService.Write("Invalid payment method selected.",ConsoleColor.Red);

            return AskForPaymentMethod(paymentMethods);
        }

        public void ShowError(string errorMessage)
        {
            ioService.Write(errorMessage, ConsoleColor.Red);
        }
    }
}