using System;
using System.Collections.Generic;
using iQuest.VendingMachine.Modules;

namespace iQuest.VendingMachine.PresentationLayer
{
    public class ShelfView
    {
        private readonly DisplayBase displayBase;

        public ShelfView()
        {
            displayBase = new DisplayBase();
        }

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
            if (product.Quantity >= 0)
            {
                displayBase.DisplayLine(product.ToString(), ConsoleColor.Green);
            }
        }
    }
}
