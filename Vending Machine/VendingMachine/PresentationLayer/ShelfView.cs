using iQuest.VendingMachine.PresentationLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine
{
    internal class ShelfView : DisplayBase
    {
        public void DisplayProducts(IEnumerable<Product> products)
        {
            Console.WriteLine();

            foreach (var product in products)
            {
                DisplayProducts(product);
            }
        }

        private void DisplayProducts(Product product)
        {
            if (product.Quantity > 0)
            {
                DisplayLine(product.ToString(), ConsoleColor.Green);
            }
            else
            {
                Console.WriteLine("Product doesn't exist in stock.");
            }
        }
    }
}
