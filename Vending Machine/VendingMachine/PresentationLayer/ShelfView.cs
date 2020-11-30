using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine
{
    public class ShelfView
    {
        public void DisplayProducts(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
    }
}
