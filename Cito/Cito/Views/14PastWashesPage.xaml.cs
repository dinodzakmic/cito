using Xamarin.Forms;

namespace Cito.Views
{
    public partial class PastWashesPage : ContentPage
    {
        public PastWashesPage()
        {
            InitializeComponent();
        }


        private void WashesDetails_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView) sender).SelectedItem = null;
        }

        private void PastWashesList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}
