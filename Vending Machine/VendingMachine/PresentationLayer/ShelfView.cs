using System;
using System.Collections.Generic;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Modules;

namespace iQuest.VendingMachine.PresentationLayer
{
    public class ShelfView
    {
        private readonly IInputOutputService ioService;

        public ShelfView(IInputOutputService inputOutputService)
        {
            ioService = inputOutputService;
        }

        public void DisplayProducts(IEnumerable<Product> products)
        {
            Console.WriteLine();

            foreach (var product in products)
            {
                DisplayProducts(product);
            }
        }

        private void DisplayProducts(Product product)
        {
            if (product.Quantity >= 0)
            {
                ioService.WriteLine(product.ToString(), ConsoleColor.Green);
            }
        }
    }
}
