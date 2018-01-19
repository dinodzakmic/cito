using System.Threading.Tasks;
using System.Windows.Input;
using Cito.Framework.Helpers;
using Cito.Views;
using Xamarin.Forms;

namespace Cito.ViewModels
{
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    public class OrderDetailsViewModel : CitoViewModelBase
    {
        private string promoCode;

        public string CardImage => "visa_logo.png";

        public string Name => CitoSettings.Current.FullName;
        public string Address => "221 Second Street";

        public string CodedCardNumber => App.Locator.CardDetails.MaskedCardNumber;

        public string SelectedPack => App.Locator.Map.WasherPackage.PackageName;

        public string SelectedPackCost => App.Locator.Map.WasherPackage.PackagePrice;

        public string CarModel => CitoSettings.Current.CarModel;

		public string CarPlate => CitoSettings.Current.LicensePlate;

        public string CarPicture => "Car.jpg";

        public string PromoCode
        {
            get => this.promoCode;
            set => this.Set(ref this.promoCode, value);
        }
        public ImageSource WasherPicture => ProfileData.ProfilePicture ?? "washer.jpg";
      

        public ICommand GoToRateWasherCommand => new Command(async () => await GoToRateWasher());
        public ICommand CancelOrderCommand => new Command(async () => await CancelOrder());

     
        private async Task GoToRateWasher()
        {
            await GoToPage(new RateWasherPage());
        }

        private async Task CancelOrder()
        {
            await GoToPreviousPage();
        }

    }
}
