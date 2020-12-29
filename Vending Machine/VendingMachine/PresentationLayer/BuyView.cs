using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PresentationLayer;
using System;

namespace iQuest.VendingMachine
{
    internal class BuyView : DisplayBase, IBuyView
    {
        ProductRepository productRepository = new ProductRepository();

        public Product RequestProduct(int columnId)
        {
            var product = productRepository.GetByColumn(columnId);

            if (product.Quantity <= 0)
            {
                throw new InsuficientStockException("Insufficent stock.");
            }

            else if(product == null)
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

            else if (int.TryParse(input, out int columnId))
            {
                return columnId;
            }
            throw new InvalidColumnException("Invalid product id.");
        }

        public void ShowError(string errorMessage)
        {
            Display(errorMessage, ConsoleColor.Red);
        }
    }
}
