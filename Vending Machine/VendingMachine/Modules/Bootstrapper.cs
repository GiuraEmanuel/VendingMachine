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
            AuthenticationService authenticationService = new AuthenticationService();
            ProductRepository productRepository = new ProductRepository();
            PaymentMethodsRepository paymentMethodsRepository = new PaymentMethodsRepository();
            InputOutputService inputOutputService = new InputOutputService();

            MainView mainView = new MainView(inputOutputService);
            LoginView loginView = new LoginView(inputOutputService);
            ShelfView shelfView = new ShelfView(inputOutputService);
            BuyView buyView = new BuyView(inputOutputService);
            DispenserView dispenserView = new DispenserView(inputOutputService);

            

            List<IUseCase> useCases = new List<IUseCase>
            {
                new LoginUseCase(authenticationService, loginView),
                new LogoutUseCase(authenticationService),
                new LookUseCase(authenticationService, productRepository, shelfView),
                new BuyUseCase(authenticationService, productRepository, dispenserView, buyView,
                    paymentMethodsRepository
                )
            };

            return new VendingMachineApplication(useCases, mainView,inputOutputService);
        }
    }
}