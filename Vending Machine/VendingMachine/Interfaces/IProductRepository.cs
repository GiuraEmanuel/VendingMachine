using System;
using System.Collections.Generic;
using System.Text;
using iQuest.VendingMachine.Modules;

namespace iQuest.VendingMachine.Interfaces
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAll();
        public Product GetByColumn(int column);
    }
}
