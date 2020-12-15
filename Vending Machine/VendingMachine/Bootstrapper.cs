using System.Collections.Generic;
using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.UseCases;

namespace iQuest.VendingMachine
{
    internal class Bootstrapper
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

            AuthenticationService authenticationService = new AuthenticationService();
            ProductRepository productRepository = new ProductRepository();
            DispenserView dispenserView = new DispenserView();
            BuyView buyView = new BuyView();

            List<IUseCase> useCases = new List<IUseCase>
            {
                new LoginUseCase(authenticationService, loginView),
                new LogoutUseCase(authenticationService),
                new LookUseCase(authenticationService, productRepository, shelfView),
                new BuyUseCase(authenticationService,productRepository,dispenserView,buyView)
            };

            return new VendingMachineApplication(useCases, mainView);
        }
    }
}