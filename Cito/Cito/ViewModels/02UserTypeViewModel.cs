using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cito.ViewModels
{
    public class UserTypeViewModel : CitoViewModelBase
    {
        public UserTypeOf UserType { get; set; }
        public enum UserTypeOf
        {
            Owner = 1,
            Washer = 2
        }

        public ICommand OwnerTypeCommand { get; private set; }
        public ICommand WasherTypeCommand { get; private set; }

        public UserTypeViewModel()
        {
            OwnerTypeCommand = new Command(async () => await OwnerType());
            WasherTypeCommand = new Command(async () => await WasherType());
        }     

        private async Task OwnerType()
        {
            UserType = UserTypeOf.Owner;
        }
        private async Task WasherType()
        {
            UserType = UserTypeOf.Washer;
        }
    }
}
