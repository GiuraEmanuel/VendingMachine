using System;
using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Repository;

namespace iQuest.VendingMachine.UseCases
{
    public class LookUseCase : IUseCase
    {
        private readonly AuthenticationService authenticationService;
        private readonly ProductRepository productRepository;
        private readonly ShelfView shelfView;
        
        public string Name => "look";

        public string Description => "Look at the vending machine's products / stock";

        public bool CanExecute => true;

        public LookUseCase(AuthenticationService authenticationService, ProductRepository productRepository, ShelfView shelfView)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.shelfView = shelfView ?? throw new ArgumentNullException(nameof(shelfView));
        }

        public void Execute()
        {
            var products = productRepository.GetAll();
            shelfView.DisplayProducts(products);
        }
    }
}
