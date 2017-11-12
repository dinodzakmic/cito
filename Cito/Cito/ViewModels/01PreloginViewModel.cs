using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using Cito.Views;
using Plugin.Connectivity;
using Xamarin.Forms;
using Color = System.Drawing.Color;

namespace Cito.ViewModels
{
    public class PreloginViewModel : CitoViewModelBase
    {
        #region Bindable properties

        #endregion
        #region Commands
        public ICommand CreateAccountCommand => new Command(async () => await CreateAccount());
        public ICommand SignInCommand => new Command(async () => await SignIn());

        public ICommand ExternalLoginCommand => new Command(async () => await ExternalLogin());

        #endregion

        public PreloginViewModel()
        {          
            
        }

        #region Methods
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
            UserDialogs.Instance.Toast("Please check your network connection", TimeSpan.FromSeconds(3));
        }
        #endregion

    }
}
