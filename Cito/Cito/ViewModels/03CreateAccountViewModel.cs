using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Cito.Framework.Utilities;
using Cito.Views;
using Xamarin.Forms;

namespace Cito.ViewModels
{
    public class CreateAccountViewModel : CitoViewModelBase
    {
        #region Bindable properties
        private string _fullName;

        public string FullName
        {
            get { return _fullName; }
            set { Set(ref _fullName, value); }
        }

        private string _carModel;

        public string CarModel
        {
            get { return _carModel; }
            set { Set(ref _carModel, value); }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { Set(ref _email, value); }
        }

        private string _number;

        public string Number
        {
            get { return _number; }
            set { Set(ref _number, value); }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { Set(ref _password, value); }
        }

        public bool IsExternalLogin { get; set; } = false;
        public bool IsSignIn { get; set; } = false;
        #endregion
        #region Commands
        public ICommand HandleNewUserCommand  => new Command(async () => await HandleNewUser());
        #endregion


        public CreateAccountViewModel()
        {
        }

        #region Methods
        private async Task HandleNewUser()
        {
            if (string.IsNullOrEmpty(FullName))
            {
                await App.NavPage.CurrentPage.DisplayAlert("Error", "Please enter full name", "OK");
                return;
            }

            if (string.IsNullOrEmpty(CarModel) && !IsSignIn)
            {
                await App.NavPage.CurrentPage.DisplayAlert("Error", "Please enter car model", "OK");
                return;
            }

            if (!StringHelpers.IsEmail(Email) && !IsExternalLogin)
            {
                await App.NavPage.CurrentPage.DisplayAlert("Error", "Please enter valid email address", "OK");
                return;
            }

            if (!StringHelpers.IsNumber(Number))
            {
                await App.NavPage.CurrentPage.DisplayAlert("Error", "Please enter valid phone number", "OK");
                return;
            }

            if (string.IsNullOrEmpty(Password) && !IsExternalLogin)
            {
                await App.NavPage.CurrentPage.DisplayAlert("Error", "Please enter password", "OK");
                return;
            }


            await GoToPage(new UserTypePage());
        }
        #endregion

    }
}
