using LiveChat.Client.Network;
using System.Windows.Input;

namespace LiveChatMobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
        }

        private AuthManager auth = new AuthManager();
        public string Username { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new DelegateCommand((_) => { login(); });
            }
        }
        private async void login()
        {
            var x = await auth.Login(Username, Password);
        }
    }
}
