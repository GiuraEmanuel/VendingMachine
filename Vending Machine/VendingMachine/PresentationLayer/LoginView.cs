using System;

namespace iQuest.VendingMachine.PresentationLayer
{
    public class LoginView
    {
        private readonly DisplayBase displayBase;

        public LoginView()
        {
            displayBase = new DisplayBase();
        }

        public string AskForPassword()
        {
            Console.WriteLine();
            displayBase.Display("Type the admin password: ", ConsoleColor.Cyan);
            return Console.ReadLine();
        }
    }
}