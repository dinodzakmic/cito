namespace Cito.ViewModels
{
    using System.Windows.Input;

    using Cito.Views;

    using Xamarin.Forms;

    public class WashingRequestsViewModel : CitoViewModelBase
    {

        public ICommand AcceptCommand => new Command(async ()=>
            await GoToPage(new DoneWashingPage()));

        public ICommand CancelCommand => new Command(async () => await GoToPreviousPage());
        
    }
}
