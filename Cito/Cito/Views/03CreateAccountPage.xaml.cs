using Xamarin.Forms;

namespace Cito.Views
{
    public partial class CreateAccountPage : ContentPage
    {
        public CreateAccountPage(bool externalLoginFirstTime = false, bool signIn = false)
        {
            InitializeComponent();
            if (externalLoginFirstTime && signIn) return;

            if (externalLoginFirstTime)
            {
                App.Locator.CreateAccount.IsExternalLogin = true;

                EmailEntry.IsVisible = false;
                CarModelEntry.NextView = NumberEntry;

                PasswordEntry.IsVisible = false;
                NumberEntry.NextView = null;
            }
            if (signIn)
            {
                App.Locator.CreateAccount.IsSignIn = true;

                CarModelEntry.IsVisible = false;
                FullNameEntry.NextView = EmailEntry;
            }
                      
        }
    }
}

