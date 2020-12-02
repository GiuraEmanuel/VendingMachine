using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine
{
    internal class Product
    {
        private string Name { get; }
        private decimal Price { get;}
        public int Quantity { get;}
        
        public Product(string name, int quantity, decimal price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name} - Quantity: {Quantity} - Price per item: {Price}$"; 
        }
    }
}
