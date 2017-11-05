using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
        #endregion
        #region Commands
        public ICommand HandleNewUserCommand { get; private set; }

        private void SetCommands()
        {
            HandleNewUserCommand = new Command(async () => await HandleNewUser());
        }


        #endregion


        public CreateAccountViewModel()
        {
            SetCommands();
        }

        #region Methods
        private async Task HandleNewUser()
        {
            await GoToPage(new UserTypePage());
        }
        #endregion

    }
}
