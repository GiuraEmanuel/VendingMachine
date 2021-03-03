using System.Collections.Generic;
using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Repository;
using iQuest.VendingMachine.UseCases;

namespace iQuest.VendingMachine.Modules
{
    public class Bootstrapper
    {
        public void Run()
        {
            VendingMachineApplication vendingMachineApplication = BuildApplication();
            vendingMachineApplication.Run();
        }

        private static VendingMachineApplication BuildApplication()
        {
            MainView mainView = new MainView();
            LoginView loginView = new LoginView();
            ShelfView shelfView = new ShelfView();
            BuyView buyView = new BuyView();
            DispenserView dispenserView = new DispenserView();

            AuthenticationService authenticationService = new AuthenticationService();
            ProductRepository productRepository = new ProductRepository();
            PaymentMethodsRepository paymentMethodsRepository = new PaymentMethodsRepository();

            List<IUseCase> useCases = new List<IUseCase>
            {
                new LoginUseCase(authenticationService, loginView),
                new LogoutUseCase(authenticationService),
                new LookUseCase(authenticationService, productRepository, shelfView),
                new BuyUseCase(authenticationService, productRepository, dispenserView, buyView,
                    paymentMethodsRepository
                )
            };

            return new VendingMachineApplication(useCases, mainView);
        }
    }
}