using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Cito.Framework.Helpers;
using Cito.Views;
using Xamarin.Forms;

namespace Cito.ViewModels
{
    public class OwnerMenuViewModel : CitoViewModelBase
    {
        #region Bindable properties

        #endregion
        #region Commands
        public ICommand GoToHomeCommand => new Command(async () => await GoToHome());
        public ICommand GoToOwnerProfileCommand => new Command(async () => await GoToOwnerProfile());
        public ICommand GoToPastWashesCommand => new Command(async () => await GoToPastWashes());
        public ICommand GoToFutureWashesCommand => new Command(async () => await GoToFutureWashes());
        public ICommand GoToPromoCodeCommand => new Command(async () => await GoToPromoCode());
        public ICommand GoToFaqCommand => new Command(async () => await GoToFaq());
        public ICommand GoToSupportCommand => new Command(async () => await GoToSupport());
        public ICommand SignOutCommand => new Command(async () => await SignOut());

       

        #endregion

        #region Methods
        private async Task GoToHome()
        {
            await GoToRootPage();
        }
        private async Task GoToOwnerProfile()
        {
            await GoToPage(new OwnerProfilePage());
        }

        private async Task GoToPastWashes()
        {
            await GoToPage(new PastWashesPage());
        }

        private async Task GoToFutureWashes()
        {
            await GoToPage(new FutureWashesPage());
        }

        private async Task GoToPromoCode()
        {
            await GoToPage(new PromoCodePage());
        }

        private async Task GoToFaq()
        {
            await GoToPage(new FaqPage());
        }

        private async Task GoToSupport()
        {
            await GoToPage(new SupportPage());
        }

        private async Task SignOut()
        {
            try
            {
                App.UpdateLoading(true);
                await Task.Delay(500);

                CitoSettings.Current.FullName = String.Empty;
                CitoSettings.Current.CarModel = String.Empty;
                CitoSettings.Current.LicensePlate = String.Empty;
                CitoSettings.Current.IsUserLoggedIn = false;

                App.NavPage = new NavigationPage(new UserTypePage());
                Application.Current.MainPage = App.NavPage;
            }
            catch (Exception e)
            {
                // ignored
            }
            finally
            {
                App.UpdateLoading(false);
            }
            
        }
        #endregion
    }
}
