using System;
using System.Linq;
using System.Threading.Tasks;
using Cito.Framework.Utilities;
using Cito.Views;
using Xamarin.Forms;

namespace Cito.ViewModels
{
    public class AvailabilityViewModel : CitoViewModelBase
    {
        #region Bindable properties

        internal StackLayout MenuItemsStack { get; set; }
        internal View FirstChild { get; set; }
        private bool _userOnline = false;

        public bool UserOnline
        {
            get { return _userOnline; }
            set
            {
                if (_userOnline == value) return;
                Set(ref _userOnline, value);
                Device.BeginInvokeOnMainThread(async () => await HandleMenu(value));
            }
        }

        #endregion

        #region Methods

        internal async Task HandleMenu(bool isOnline)
        {
            try
            {
                App.UpdateLoading(true);
                await Task.Delay(500);
                Page newRootPage;

                if (isOnline)
                {
                    MenuItemsStack = ((ContentPage) App.MenuPage.Master).FindByName<StackLayout>("ItemsLayout");
                    FirstChild = MenuItemsStack.Children.FirstOrDefault();
                    MenuItemsStack.Children.RemoveAt(0);
                    MenuItemsStack.Children.Insert(1, FirstChild);
                    newRootPage = new MapPage();
                    
                }
                else
                {
                    MenuItemsStack = ((ContentPage) App.MenuPage.Master).FindByName<StackLayout>("ItemsLayout");
                    FirstChild = MenuItemsStack.Children.FirstOrDefault();
                    MenuItemsStack.Children.RemoveAt(0);
                    MenuItemsStack.Children.Insert(1, FirstChild);
                    newRootPage = new AvailabiltyPage();                   
                }

                App.NavPage = new NavigationPage(newRootPage);
                App.MenuPage.Detail = App.NavPage;
            }
            catch (Exception e)
            {
                // ignored
            }
            finally
            {
                App.UpdateLoading(false);
            }

            #endregion
        }
    }
}

