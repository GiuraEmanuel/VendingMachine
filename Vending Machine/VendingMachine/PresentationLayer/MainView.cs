using System.Collections.Generic;
using iQuest.VendingMachine.Interfaces;

namespace iQuest.VendingMachine.PresentationLayer
{
    public class MainView : DisplayBase
    {
        public void DisplayApplicationHeader()
        {
            ApplicationHeaderControl applicationHeaderControl = new ApplicationHeaderControl();
            applicationHeaderControl.Display();
        }

        public IUseCase ChooseCommand(IEnumerable<IUseCase> useCases)
        {
            CommandSelectorControl commandSelectorControl = new CommandSelectorControl
            {
                UseCases = useCases
            };
            return commandSelectorControl.Display();
        }
    }
}