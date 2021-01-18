using System;
using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Modules;

namespace iQuest.VendingMachine.UseCases
{
    internal class BuyUseCase : IUseCase
    {
        #region Fields

        private readonly IAuthenticationService authenticationService;
        private readonly IProductRepository productRepository;
        private readonly IDispenserView dispenserView;
        private readonly IBuyView buyView;

        #endregion

        public BuyUseCase(IAuthenticationService authenticationService, IProductRepository productRepository,
            IDispenserView dispenserView, IBuyView buyView)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.dispenserView = dispenserView ?? throw new ArgumentNullException(nameof(dispenserView));
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
        }

        #region Properties

        public string Name => "buy";

        public string Description => "Buy product";

        public bool CanExecute => !authenticationService.IsUserAuthenticated;

        #endregion

        public void Execute()
        {
            int columnId = buyView.AskForColumnId();
            Product product = productRepository.GetByColumn(columnId);

            if (product == null)
            {
                throw new InvalidColumnException("Invalid column provided.");
            }

            if (product.Quantity <= 0)
            {
                throw new InsufficientStockException("Insufficient stock.");
            }

            product.DecrementQuantity();

            dispenserView.DispenseProduct(product.Name);
        }
    }
}