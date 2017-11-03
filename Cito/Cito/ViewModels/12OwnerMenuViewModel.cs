using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cito.ViewModels
{
    public class OwnerMenuViewModel : CitoViewModelBase
    {
        #region Bindable properties

        #endregion
        #region Commands
        public ICommand MenuItemTest { get; private set; }
        private void SetCommands()
        {
            MenuItemTest = new Command(() => App.MenuPage.IsPresented = false);
        }
        #endregion

        public OwnerMenuViewModel()
        {
            SetCommands();
        }

        #region Methods

        #endregion
    }
}
