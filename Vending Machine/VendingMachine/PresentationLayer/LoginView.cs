using iQuest.VendingMachine.Interfaces;
using System;

namespace iQuest.VendingMachine.PresentationLayer
{
    public class LoginView
    {
        private readonly IInputOutputService ioService;

        public LoginView(IInputOutputService inputOutputService)
        {
            ioService = inputOutputService;
        }

        public string AskForPassword()
        {
            Console.WriteLine();
            ioService.Write("Type the admin password: ", ConsoleColor.Cyan);
            return Console.ReadLine();
        }
    }
}