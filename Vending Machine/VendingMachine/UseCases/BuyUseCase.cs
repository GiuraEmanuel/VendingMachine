using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.Exceptions;
using System;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class BuyUseCase : IUseCase
    {
        private readonly AuthenticationService authenticationService;
        private readonly ProductRepository productRepository;
        private readonly DispenserView dispenserView;
        private readonly BuyView buyView;

        public BuyUseCase(AuthenticationService authenticationService, ProductRepository productRepository, DispenserView dispenserView, BuyView buyView)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.dispenserView = dispenserView ?? throw new ArgumentNullException(nameof(dispenserView));
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
        }

        public string Name => "buy";

        public string Description => "Buy product";

        public bool CanExecute => !authenticationService.IsUserAuthenticated;

        public void Execute()
        {
            try
            {
                var columnId = buyView.AskForColumnId();
                var product = productRepository.GetByColumn(columnId);

                if (product == null)
                {
                    throw new InvalidColumnException("Invalid column provided.");
                }

                if (product.Quantity <= 0)
                {
                    throw new InsuficientStockException("Insufficent stock.");
                }

                product.DecrementQuantity();

                dispenserView.DispenseProduct(product.Name);

        }
            catch (CancelException ex)
            {
                buyView.ShowError(ex.Message);
            }

            catch (Exception ex)
            {
                buyView.ShowError(ex.Message);
            }
        }
    }
}
