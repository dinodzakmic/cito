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
    public class OwnerMenuViewModel : CitoViewModelBase
    {
        #region Bindable properties

        #endregion
        #region Commands
        public ICommand GoToHomeCommand { get; private set; }
        public ICommand GoToOwnerProfileCommand { get; private set; }
        public ICommand GoToPastWashersCommand { get; private set; }
        public ICommand GoToFutureWashersCommand { get; private set; }
        public ICommand GoToPromoCodeCommand { get; private set; }
        public ICommand GoToFaqCommand { get; private set; }
        public ICommand GoToSupportCommand { get; private set; }
        private void SetCommands()
        {
            GoToHomeCommand = new Command(async () => await GoToHome());
            GoToOwnerProfileCommand = new Command(async () => await GoToOwnerProfile());
            GoToPastWashersCommand = new Command(async () => await GoToPastWashers());
            GoToFutureWashersCommand = new Command(async () => await GoToFutureWashers());
            GoToPromoCodeCommand = new Command(async () => await GoToPromoCode());
            GoToFaqCommand = new Command(async () => await GoToFaq());
            GoToSupportCommand = new Command(async () => await GoToSupport());
        }

        #endregion

        public OwnerMenuViewModel()
        {
            SetCommands();
        }

        #region Methods
        private async Task GoToHome()
        {
            await GoToRootPage();
        }
        private async Task GoToOwnerProfile()
        {
            await GoToPage(new OwnerProfilePage());
        }
        private async Task GoToPastWashers()
        {
            await GoToPage(new PastWashersPage());
        }
        private async Task GoToFutureWashers()
        {
            await GoToPage(new PastWashersPage());
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
        #endregion
    }
}
