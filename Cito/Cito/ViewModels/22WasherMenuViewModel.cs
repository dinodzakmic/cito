using System.Threading.Tasks;
using System.Windows.Input;
using Cito.Views;
using Xamarin.Forms;

namespace Cito.ViewModels
{
    public class WasherMenuViewModel : CitoViewModelBase
    {
        #region Bindable properties

        #endregion
        #region Commands
        public ICommand GoToHomeCommand => new Command(async () => await GoToHome());
        
        public ICommand GoToEarningsCommand => new Command(async () => await GoToEarnings());

        public ICommand GoToSupportCommand => new Command(async () => await GoToSupport());

        #endregion

        #region Methods
        private async Task GoToHome()
        {
            await GoToRootPage();
        }

        private async Task GoToEarnings()
        {
        }

        private async Task GoToSupport()
        {
            await GoToPage(new SupportPage());
        }
        #endregion
    }
}
