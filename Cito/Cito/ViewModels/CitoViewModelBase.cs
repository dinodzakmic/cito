using System;
using System.Linq;
using System.Threading.Tasks;
using Cito.Views;
using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace Cito.ViewModels
{
    public class CitoViewModelBase : ViewModelBase
    {
        /// <summary>
        /// Navigates to a new page.
        /// </summary>
        /// <param name="page">
        /// Page should be initialized e.g. new CustomPage()
        /// </param>
        /// <returns></returns>
        public async Task GoToPage(Page page)
        {
            try
            {
                App.InstantiatingPageType = page.GetType();
                App.UpdateLoading(true);
                await Task.Delay(500);
                await App.NavPage.Navigation.PushAsync(page);
            }
            catch (Exception e)
            {
                // ignored
            }
            finally
            {
                App.UpdateLoading(false);
            }
        }

        /// <summary>
        /// Navigates to a previous page in stack.
        /// </summary>
        /// <returns></returns>
        public async Task GoToPreviousPage()
        {
            try
            {
                App.InstantiatingPageType = App.NavPage.Navigation.NavigationStack.Last().GetType();                
                App.UpdateLoading(true);
                await Task.Delay(500);
                await App.NavPage.Navigation.PopAsync();            
            }
            catch (Exception e)
            {
                // ignored
            }
            finally
            {
                App.UpdateLoading(false);
            }
        }

        /// <summary>
        /// Navigates to a root page of the app.
        /// </summary>
        /// <returns></returns>
        public async Task GoToRootPage()
        {
            try
            {
                App.UpdateLoading(true);
                await Task.Delay(500);
                await App.NavPage.Navigation.PopToRootAsync();
            }
            catch (Exception e)
            {
                // ignored
            }
            finally
            {
                App.UpdateLoading(false);
            }
        }

        /// <summary>
        /// Navigates to a page with side menu. OwnerMenu page content is defined in OwnerMenu.xaml.
        /// </summary>
        /// <param name="page">
        /// Page should be initialized e.g. new CustomPage() and this page represents Detail.
        /// </param>
        /// <returns></returns>
        public async Task GoToMasterRootPage(Page page, UserTypeViewModel.UserTypeOf userType)
        {
            try
            {
                App.InstantiatingPageType = page.GetType();
                App.UpdateLoading(true);
                await Task.Delay(500);
                App.NavPage = new NavigationPage(page);
                App.MenuPage = userType == UserTypeViewModel.UserTypeOf.Owner 
                    ? new OwnerMenu() { Detail = App.NavPage} 
                    : new OwnerMenu() {Detail = App.NavPage}; // TODO: add WasherMenu 
                App.Current.MainPage = App.MenuPage;
            }
            catch (Exception e)
            {
                // ignored
            }
            finally
            {
                App.UpdateLoading(false);
            }

        }
     
    }
}

