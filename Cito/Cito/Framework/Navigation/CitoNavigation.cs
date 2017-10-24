using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cito.Framework.Navigation
{
    static class CitoNavigation
    {
        private static Stack<ViewTitle> ViewStack { get; set; } = new Stack<ViewTitle>();
        public static bool PageInitialized = false;

        public static CitoNavigationPage MainPage =>
            (CitoNavigationPage)((NavigationPage) (Application.Current.MainPage as MasterDetailPage)?.Detail)?.CurrentPage;




        public static async Task PushPage(CitoNavigationPage page)
        {
            if (MainPage != null)
            {
                var scrollContent = MainPage.ScrollContent;
                ViewStack.Push(new ViewTitle(scrollContent.Content, MainPage.CitoTitle));
            }

            var viewTitle = new ViewTitle(page.Content, page.Title, page.NavigationBarVisible);
            await RenderContent(viewTitle);
        }

        public static async Task PopPage()
        {
            if (ViewStack.Any())
            {
                var content = ViewStack.Pop();
                await RenderContent(content);
            }
            else
            {
                
            }
        }

        internal static async Task RenderContent(ViewTitle viewTitle)
        {
            if (MainPage != null)
            {
                await MainPage.ScrollContent.Content.FadeTo(opacity: 0, length: 100U ,easing: Easing.SinOut);
                MainPage.ScrollContent.Content = viewTitle.View;
                MainPage.ScrollContent.Content.Opacity = 0;
                MainPage.CitoTitle = viewTitle.Title;
                MainPage.NavigationBar.IsVisible = viewTitle.NavigationBarVisible;
                MainPage.CitoBackgroundImage.IsVisible = viewTitle.BackgroundImageVisible;
                await Task.Delay(50);
                await MainPage.ScrollContent.Content.FadeTo(opacity: 1, length: 100U, easing: Easing.SinIn);
            }
        }
    }


    class ViewTitle
    {
        public View View { get; set; }
        public string Title { get; set; }
        public bool NavigationBarVisible { get; set; }
        public bool BackgroundImageVisible { get; set; }

        public ViewTitle(View view, string title, bool navigationBarVisible = true, bool backgroundImageVisible = true)
        {
            View = view;
            Title = title;
            NavigationBarVisible = navigationBarVisible;
            BackgroundImageVisible = backgroundImageVisible;
        }
    }
}
