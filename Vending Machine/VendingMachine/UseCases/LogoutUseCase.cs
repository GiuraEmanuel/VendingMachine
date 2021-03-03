using System;
using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.Interfaces;

namespace iQuest.VendingMachine.UseCases
{
    public class LogoutUseCase : IUseCase
    {
        private readonly AuthenticationService authenticationService;

        public string Name => "logout";

        public string Description => "Restrict access to administration section.";

        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public LogoutUseCase(AuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        public void Execute()
        {
            authenticationService.Logout();
        }
    }
}