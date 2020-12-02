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
                if (product!= null && product.Quantity > 0)
                {
                    DisplayLine(product.ToString(), ConsoleColor.Green);
                }
                else
                {
                    throw new NullReferenceException("Product is null.");
                }
            }
        }
    }
}
