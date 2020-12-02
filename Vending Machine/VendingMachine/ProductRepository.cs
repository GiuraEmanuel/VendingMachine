using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine
{
    internal class ProductRepository
    {
        private List<Product> products = new List<Product>
        {
            new Product("Cigars",5,10.00M),
            new Product("Coca Cola", 5,3.00M),
            new Product("Chocolate bars",5,2.00M),
            new Product("Sandwich", 5, 4.00M)
        };
        
        public IEnumerable<Product> GetAll()
        {
            return products;
        }
    }
}
