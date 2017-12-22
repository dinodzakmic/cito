using Xamarin.Forms;

namespace Cito.Views
{
    public partial class OwnerProfilePage : ContentPage
    {
        public OwnerProfilePage()
        {
            InitializeComponent();
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}
