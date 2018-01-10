using Cito.ViewModels;
using Xamarin.Forms;

namespace Cito.Views
{
    public partial class OwnerProfilePage : ContentPage
    {
        public OwnerProfilePage()
        {
            InitializeComponent();
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    MyCarsList.SelectedItem = null;
        //}

        private void MyCarsList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var bc = (OwnerProfileViewModel)MyCarsList.BindingContext;
            if (bc.SelectedCar == null) return;
            bc.EditingCar = new OwnerProfileViewModel.Car(bc.SelectedCar);
            bc.GoToPage(new CarDetailsPage() { BindingContext = bc });
            this.MyCarsList.SelectedItem = null;
        }
    }
}
