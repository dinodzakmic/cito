using System;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace Cito.ViewModels
{
    public class CitoViewModelBase : ViewModelBase
    {
        public async Task GoToPage(Page page)
        {
            try
            {
                App.InstantiatingPageType = page.GetType();
                App.UpdateLoading(true);
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

        public async Task GoToPreviousPage()
        {
            try
            {
                App.InstantiatingPageType = App.NavPage.Navigation.NavigationStack.Last().GetType();
                await App.NavPage.Navigation.PopAsync();
                App.UpdateLoading(true);
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

        public async Task GoToRootPage()
        {
            try
            {
                App.UpdateLoading(true);
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
    }
}

