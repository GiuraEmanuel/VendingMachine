using iQuest.VendingMachine.Interfaces;

namespace iQuest.VendingMachine.Authentication
{
    internal class AuthenticationService : IAuthenticationService
    {
        public bool IsUserAuthenticated { get; private set; }

        public void Login(string password)
        {
            if (password == "1234")
                IsUserAuthenticated = true;
            else
                throw new InvalidPasswordException();
        }

        public void Logout()
        {
            IsUserAuthenticated = false;
        }
    }
}