using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.Interfaces
{
    internal interface IProductRepository
    {
        public IEnumerable<Product> GetAll();
        public Product GetByColumn(int column);
    }
}
