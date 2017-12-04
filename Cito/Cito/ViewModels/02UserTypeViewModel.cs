using System.Threading.Tasks;
using System.Windows.Input;
using Cito.Framework.Helpers;
using Cito.Views;
using Xamarin.Forms;

namespace Cito.ViewModels
{
    public class UserTypeViewModel : CitoViewModelBase
    {
        #region Bindable properties
        public UserTypeOf UserType { get; set; }
        public enum UserTypeOf
        {
            Owner = 1,
            Washer = 2
        }

        #endregion
        #region Commands
        public ICommand OwnerTypeCommand { get; private set; }
        public ICommand WasherTypeCommand { get; private set; }

        private void SetCommands()
        {
            OwnerTypeCommand = new Command(async () => await OwnerType());
            WasherTypeCommand = new Command(async () => await WasherType());
        }
        #endregion

        public UserTypeViewModel()
        {
           SetCommands();
        }

        #region Methods
        private async Task OwnerType()
        {
            UserType = UserTypeOf.Owner;
            CitoSettings.Current.IsUserLoggedIn = true;
            CitoSettings.Current.UserType = UserType.ToString();
            await GoToMasterRootPage(new MapPage(), UserType);           
        }
        private async Task WasherType()
        {
            UserType = UserTypeOf.Washer;
            CitoSettings.Current.IsUserLoggedIn = true;
            CitoSettings.Current.UserType = UserType.ToString();
            await GoToMasterRootPage(new AvailabiltyPage(), UserType);            
        }

        #endregion

    }
}
