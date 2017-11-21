namespace Cito.ViewModels
{
    using System.Windows.Input;

    using Cito.Views;

    using Xamarin.Forms;

    public class AcceptWashViewModel : CitoViewModelBase
    {

        public ICommand AcceptCommand => new Command(async ()=>
            await GoToPage(new TakePictureWashingDonePage()));

        public ICommand CancelCommand => new Command(async () => await GoToPreviousPage());
        
    }
}
