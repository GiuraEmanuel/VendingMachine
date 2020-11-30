using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine
{
    public class ProductRepository
    {
        private List<Product> products = new List<Product>
        {
            new Product("Cigars",5),
            new Product("Coca Cola", 5),
            new Product("Chocolate bars",5),
            new Product("Sandwich", 5)
        };
        
        public IEnumerable<Product> GetAll()
        {
            return products;
        }
    }
}
