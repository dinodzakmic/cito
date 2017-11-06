namespace Cito.ViewModels
{
    using GalaSoft.MvvmLight;

    public class RateWasherViewModel : CitoViewModelBase
    {

        private int rating;

        public int Rating
        {
            get => this.rating;
            set => this.Set(ref rating, value);
        }

        public string CarPicture => "Car.jpg";
    }
}
