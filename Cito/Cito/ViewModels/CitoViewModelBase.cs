using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                await App.NavPage.Navigation.PushAsync(page);
            }
            catch (Exception e)
            {
                // ignored
            }
        }

        public async Task GoToPreviousPage()
        {
            try
            {
                await App.NavPage.Navigation.PopAsync();
            }
            catch (Exception e)
            {
                // ignored
            }
        }

        public async Task GoToRootPage()
        {
            try
            {
                await App.NavPage.Navigation.PopToRootAsync();
            }
            catch (Exception e)
            {
                // ignored
            }
        }
    }
}
