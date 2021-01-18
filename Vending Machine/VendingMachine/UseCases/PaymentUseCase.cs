using iQuest.VendingMachine.Interfaces;
using System;
using System.Collections.Generic;
using iQuest.VendingMachine.Modules;

namespace iQuest.VendingMachine.UseCases
{
    internal class PaymentUseCase : IUseCase
    {
        private readonly IAuthenticationService authenticationService;

        private readonly IBuyView buyView;

        private readonly List<IPaymentAlgorithm> paymentAlgorithms;

        public string Name => "pay";

        public string Description => "Payment for selected product";

        public bool CanExecute => !authenticationService.IsUserAuthenticated;

        public PaymentUseCase(IAuthenticationService authenticationService, IBuyView buyView)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            paymentAlgorithms = new List<IPaymentAlgorithm> {new CardPayment(), new CashPayment()};
        }

        public void Execute()
        {
            
        }
    }
}
