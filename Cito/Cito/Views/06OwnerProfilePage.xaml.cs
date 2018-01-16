using Cito.ViewModels;
using Xamarin.Forms;

namespace Cito.Views
{
    public partial class OwnerProfilePage : ContentPage
    {
        public OwnerProfilePage()
        {
            InitializeComponent();
            var bc = (OwnerProfileViewModel)this.BindingContext;

            if (bc.ProfilePicture != null)
            {
                ProfilePicture.Source = bc.ProfilePicture; //hacky as hell
            }
            else
            {
                ProfilePicture.Source = "OwnerProfileImage.png";
            }
        }

        //private void OwnerProfilePage_BindingContextChanged(object sender, System.EventArgs e)
        //{
        //    var bc = (OwnerProfileViewModel) this.BindingContext;

        //    if (bc.ProfilePicture != null)
        //    {
        //        ProfilePicture.Source = bc.ProfilePicture; //hacky as hell
        //    }
        //    else
        //    {
        //        ProfilePicture.Source = "OwnerProfileImage.png";
        //    }
        //}

        ////protected override void OnAppearing()
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
