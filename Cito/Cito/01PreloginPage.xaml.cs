using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Cito
{
    public partial class PreloginPage : ContentPage
    {
        public PreloginPage()
        {
            InitializeComponent();
        }

        private void ExternalLoginClicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new CreateAccountPage(externalLoginFirstTime: true);
        }

        private void CreateAccountClicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new CreateAccountPage();
        }

        private void SignInClicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new CreateAccountPage(signIn: true);
        }
    }
}
