using System;

namespace Cito.Framework.Navigation
{
    public partial class StartPage : Framework.Navigation.CitoNavigationPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await CitoNavigation.PushPage(new Framework.Navigation.SecondPage());
        }
    }
}
