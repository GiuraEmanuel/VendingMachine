using iQuest.VendingMachine.Interfaces;
using System;
using iQuest.VendingMachine.Modules;
using iQuest.VendingMachine.Repository;
using iQuest.VendingMachine.PresentationLayer;

namespace iQuest.VendingMachine.UseCases
{
    public class PaymentUseCase : IUseCase
    {
        private readonly IAuthenticationService authenticationService;

        private readonly BuyView buyView;

        private readonly IPaymentMethodProcessor paymentMethodsRepository;

        private readonly Product product;

        private readonly IInputOutputService ioService;

        public string Name => "pay";

        public string Description => "Payment for selected product";

        public bool CanExecute => !authenticationService.IsUserAuthenticated;

        public PaymentUseCase(IAuthenticationService authenticationService, BuyView buyView,
            IPaymentMethodProcessor paymentMethodsRepository,Product product, IInputOutputService inputOutputService)
        {
            this.authenticationService =
                authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            ioService = inputOutputService;
            this.paymentMethodsRepository = new PaymentMethodProcessor(ioService);
            this.product = product ?? throw new ArgumentNullException(nameof(product));
        }

        public void Execute()
        {
            var paymentMethodId = buyView.AskForPaymentMethod(paymentMethodsRepository.GetAllPaymentMethods());

            foreach (var paymentMethod in paymentMethodsRepository.GetAllPaymentMethods())
            {
                if (paymentMethodId == paymentMethod.Id)
                {
                    paymentMethod.Run(product.Price);
                }
            }
        }
    }
}