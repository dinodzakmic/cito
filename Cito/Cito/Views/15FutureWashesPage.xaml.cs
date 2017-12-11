using Xamarin.Forms;

namespace Cito.Views
{
    public partial class FutureWashesPage : ContentPage
    {
        public FutureWashesPage()
        {
            InitializeComponent();
        }

        //private void FutureWashesList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    ((ListView)sender).SelectedItem = null;
        //}

        private void WashesDetails_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}
