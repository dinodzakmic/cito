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
        public ICommand CreateAccountCommand { get; private set; }
        public ICommand SignInCommand { get; private set; }

        public ICommand ExternalLoginCommand { get; private set; }

        private void SetCommands()
        {
            CreateAccountCommand = new Command(async () => await CreateAccount());
            SignInCommand = new Command(async () => await SignIn());
            ExternalLoginCommand = new Command(async () => await ExternalLogin());
        }

        #endregion

        public PreloginViewModel()
        {
            //move this to Base
            CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
            {
                var tmp = args.IsConnected;
            };

            SetCommands();
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
            UserDialogs.Instance.Toast("Test", TimeSpan.FromSeconds(3));
        }
        #endregion

    }
}
