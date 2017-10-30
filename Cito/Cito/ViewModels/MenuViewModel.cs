using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cito.ViewModels
{
    public class MenuViewModel : CitoViewModelBase
    {
        public ICommand MenuItemTest { get; private set; }

        public MenuViewModel()
        {
            MenuItemTest = new Command(() => App.MenuPage.IsPresented = false);
        }
    }
}
