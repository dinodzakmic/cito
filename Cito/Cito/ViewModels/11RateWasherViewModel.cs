using System.Windows.Input;
using Xamarin.Forms;

namespace Cito.ViewModels
{
    public class RateWasherViewModel : CitoViewModelBase
    {

        private int rating;

        public int Rating
        {
            get { return this.rating; }
            set { this.Set(ref rating, value); }
        }

        public string CarPicture => "Car.jpg";

        public ICommand RateWasherCommand => new Command(async () => await GoToRootPage());
    }
}
