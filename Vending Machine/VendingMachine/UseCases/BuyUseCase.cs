using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.Modules;
using System;
using iQuest.VendingMachine.Repository;
using iQuest.VendingMachine.PresentationLayer;

namespace iQuest.VendingMachine.UseCases
{
    public class BuyUseCase : IUseCase
    {
        #region Fields

        private readonly IAuthenticationService authenticationService;
        private readonly IProductRepository productRepository;
        private readonly DispenserView dispenserView;
        private readonly BuyView buyView;
        private readonly IPaymentMethodsRepository paymentMethodsRepository;

        #endregion

        public BuyUseCase(IAuthenticationService authenticationService, IProductRepository productRepository,
            DispenserView dispenserView, BuyView buyView, IPaymentMethodsRepository paymentMethodsRepository)
        {
            this.authenticationService =
                authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.dispenserView = dispenserView ?? throw new ArgumentNullException(nameof(dispenserView));
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.paymentMethodsRepository = new PaymentMethodsRepository();
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

            try
            {
                var paymentUseCase =
                    new PaymentUseCase(authenticationService, buyView, paymentMethodsRepository, product);

                paymentUseCase.Execute();

                product.DecrementQuantity();

                dispenserView.DispenseProduct(product.Name);
            }

            catch (CancelException cancelException)
            {
                buyView.ShowError(cancelException.Message);
            }
            catch (InvalidColumnException invalidColumnException)
            {
                buyView.ShowError(invalidColumnException.Message);
            }
        }
    }
}