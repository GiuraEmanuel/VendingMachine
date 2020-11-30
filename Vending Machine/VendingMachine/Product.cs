using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine
{
    public class Product
    {
        public int Column { get;}
        public string Name { get; }
        public float Price { get;}
        public int Quantity { get;}

        public Product(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"{Name} - {Quantity}"; 
        }
    }
}
