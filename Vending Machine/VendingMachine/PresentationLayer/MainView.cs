using System.Collections.Generic;
using iQuest.VendingMachine.Interfaces;

namespace iQuest.VendingMachine.PresentationLayer
{
    public class MainView
    {
        private readonly IInputOutputService ioService;

        public MainView(IInputOutputService inputOutputService)
        {
            ioService = inputOutputService;
        }

        public void DisplayApplicationHeader()
        {
            ApplicationHeaderControl applicationHeaderControl = new ApplicationHeaderControl(ioService);
            applicationHeaderControl.Display();
        }

        public IUseCase ChooseCommand(IEnumerable<IUseCase> useCases)
        {
            CommandSelectorControl commandSelectorControl = new CommandSelectorControl(ioService)
            {
                UseCases = useCases
            };
            return commandSelectorControl.Display();
        }
    }
}