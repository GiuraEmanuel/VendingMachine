using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using System;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class BuyUseCase : IUseCase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IProductRepository productRepository;
        private readonly IDispenserView dispenserView;
        private readonly IBuyView buyView;

        public BuyUseCase(IAuthenticationService authenticationService, IProductRepository productRepository, IDispenserView dispenserView, IBuyView buyView)
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
                int columnId = buyView.AskForColumnId();
                Product product = productRepository.GetByColumn(columnId);
    
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
