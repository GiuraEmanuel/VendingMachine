using System.Collections.Generic;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Modules;

namespace iQuest.VendingMachine.Repository
{
    internal class ProductRepository : IProductRepository
    {
        private readonly List<Product> products = new List<Product>
        {
            new Product(1,"Cigars",5,10M),
            new Product(2,"Coca Cola", 5,3M),
            new Product(3,"Chocolate bars",5,2M),
            new Product(4,"Sandwich", 5, 4M),
            new Product(5,"Apple", 0, 1M)
        };
        
        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        public Product GetByColumn(int columnId) => products.Find(products => products.ColumnId == columnId);
    }
}
