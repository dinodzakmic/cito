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
        public ICommand HandleNewUserCommand { get; private set; }

        public CreateAccountViewModel()
        {
            HandleNewUserCommand = new Command(async () => await HandleNewUser());
        }

        private async Task HandleNewUser()
        {
            await GoToPage(new UserTypePage());
        }
    }
}
