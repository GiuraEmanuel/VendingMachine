using System;
using System.Collections.Generic;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PresentationLayer;

namespace iQuest.VendingMachine.Modules
{
    internal class VendingMachineApplication
    {
        private readonly List<IUseCase> useCases;
        private readonly MainView mainView;
        private readonly BuyView buyView;

        public VendingMachineApplication(List<IUseCase> useCases, MainView mainView)
        {
            this.useCases = useCases ?? throw new ArgumentNullException(nameof(useCases));
            this.mainView = mainView ?? throw new ArgumentNullException(nameof(mainView));
            buyView = new BuyView();
        }

        public void Run()
        {
            mainView.DisplayApplicationHeader();

            while (true)
            {
                try
                {
                   List<IUseCase> availableUseCases = GetExecutableUseCases();

                   IUseCase useCase = mainView.ChooseCommand(availableUseCases);
                   useCase.Execute();
                }

                catch (Exception ex)
                {
                   buyView.ShowError(ex.Message);
                }
            }
        }

        private List<IUseCase> GetExecutableUseCases()
        {
            List<IUseCase> executableUseCases = new List<IUseCase>();

            foreach (IUseCase useCase in useCases)
            {
                if(useCase.CanExecute)
                    executableUseCases.Add(useCase);
            }

            return executableUseCases;
        }
    }
}