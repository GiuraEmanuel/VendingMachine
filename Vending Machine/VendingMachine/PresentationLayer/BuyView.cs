using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.PresentationLayer;
using System;

namespace iQuest.VendingMachine
{
    internal class BuyView : DisplayBase
    {
        ProductRepository productRepository = new ProductRepository();

        public Product RequestProduct(int columnId)
        {
            var product = productRepository.GetByColumn(columnId);
            if (product == null)
            {
                throw new InvalidColumnException("Product does not exist.");
            }

            if (product.Quantity <= 0)
            {
                throw new InsuficientStockException("Insufficent stock.");
            }

            return product;
        }

        public int AskForColumnId()
        {
            Console.WriteLine();
            Display("Enter product id: ", ConsoleColor.Cyan);
            var input = Console.ReadLine();
            int columnId;
            if (int.TryParse(input, out columnId) || input == null)
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
