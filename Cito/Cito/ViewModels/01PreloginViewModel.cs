using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Cito.Views;
using Xamarin.Forms;

namespace Cito.ViewModels
{
    public class PreloginViewModel : CitoViewModelBase
    {
        public ICommand CreateAccountCommand { get; private set; }
        public ICommand SignInCommand { get; private set; }

        public ICommand ExternalLoginCommand { get; private set; }

        public PreloginViewModel()
        {
            CreateAccountCommand = new Command(async () => await CreateAccount());
            SignInCommand = new Command(async () => await SignIn());
            ExternalLoginCommand = new Command(async () => await ExternalLogin());
        }

        private async Task CreateAccount()
        {
            await GoToPage(new CreateAccountPage());
        }

        private async Task SignIn()
        {
            await GoToPage(new CreateAccountPage(signIn: true));
        }

        private async Task ExternalLogin()
        {
            
        }
    }
}
