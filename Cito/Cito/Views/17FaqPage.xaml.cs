namespace Cito.Views
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    public partial class FaqPage : ContentPage
    {
        public FaqPage()
        {
            InitializeComponent();
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            this.FaqList.SelectedItem = null;
        }
    }
}