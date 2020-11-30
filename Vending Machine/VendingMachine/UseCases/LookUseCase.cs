using iQuest.VendingMachine.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine
{
    public class LookUseCase : IUseCase
    {
        private readonly AuthenticationService authenticationService;

        public string Name => "look";

        public string Description => "Look at the vending machine's products / stock";

        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public void Execute()
        {
            ProductRepository productRepository = new ProductRepository();
            var products = productRepository.GetAll();
            ShelfView shelfView = new ShelfView();
            shelfView.DisplayProducts(products);
        }
    }
}
