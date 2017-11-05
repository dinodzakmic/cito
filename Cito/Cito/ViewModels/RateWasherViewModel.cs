namespace Cito.ViewModels
{
    using GalaSoft.MvvmLight;

    public class RateWasherViewModel : ViewModelBase
    {

        private int rating;

        public int Rating
        {
            get => this.rating;
            set => this.Set(ref rating, value);
        }
    }
}
