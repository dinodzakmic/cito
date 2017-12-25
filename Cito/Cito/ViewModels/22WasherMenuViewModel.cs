using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Cito.Framework.Helpers;
using Cito.Views;
using Xamarin.Forms;

namespace Cito.ViewModels
{
    public class WasherMenuViewModel : CitoViewModelBase
    {
        #region Bindable properties

        #endregion
        #region Commands
        public ICommand GoToAvailabiltyCommand => new Command(async () => await GoToAvailabilty());
        
        public ICommand GoToMapCommand => new Command(async () => await GoToMap());
     
        public ICommand GoToEarningsCommand => new Command(async () => await GoToEarnings());

        public ICommand GoToFaqCommand => new Command(async () => await GoToFaq());

        public ICommand GoToSupportCommand => new Command(async () => await GoToSupport());

        public ICommand SignOutCommand => new Command(async () => await SignOut());


        #endregion

        #region Methods
        private async Task GoToAvailabilty()
        {
            await GoToPage(new AvailabiltyPage());
        }

        private async Task GoToMap()
        {
            await GoToPage(new MapPage());
        }

        private async Task GoToEarnings()
        {
            await GoToPage(new EarningsPage());
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
