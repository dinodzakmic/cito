using System.Threading.Tasks;
using System.Windows.Input;
using Cito.Views;
using Xamarin.Forms;

namespace Cito.ViewModels
{
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    public class OrderDetailsViewModel : CitoViewModelBase
    {
        public string CardImage => "visa.png";

        public string Name => "John Johnson";

        public string Address => "221 Second Street";

        public string CodedCardNumber => "**** **** **** 5542";

        public string SelectedPack => "Standard Pack";

        public string SelectedPackCost => "12.99";

        public string CarModel => "Audi A8";

        public string CarPlate => "TR6 1971";

        public string CarPicture => "Car.jpg";

        public string WasherPicture => "washer.jpg";

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
