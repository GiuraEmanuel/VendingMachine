using iQuest.VendingMachine.Interfaces;
using System.Collections.Generic;

namespace iQuest.VendingMachine
{
    internal class ProductRepository : IProductRepository
    {
        private List<Product> products = new List<Product>
        {
            new Product(1,"Cigars",5,10.00M),
            new Product(2,"Coca Cola", 5,3.00M),
            new Product(3,"Chocolate bars",5,2.00M),
            new Product(4,"Sandwich", 5, 4.00M),
            new Product(5,"Apple", 0, 1.00M)
        };
        
        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        public Product GetByColumn(int columnId)
        {
            return products.Find(products => products.ColumnId == columnId);
        }
    }
}
