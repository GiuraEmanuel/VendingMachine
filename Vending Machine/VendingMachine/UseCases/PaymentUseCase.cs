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

        private readonly IPaymentMethodsRepository paymentMethodsRepository;

        private readonly Product product;

        public string Name => "pay";

        public string Description => "Payment for selected product";

        public bool CanExecute => !authenticationService.IsUserAuthenticated;

        public PaymentUseCase(IAuthenticationService authenticationService, BuyView buyView,
            IPaymentMethodsRepository paymentMethodsRepository,Product product)
        {
            this.authenticationService =
                authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.paymentMethodsRepository = new PaymentMethodsRepository();
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