using System;

namespace Cito.Framework.Navigation
{
    public partial class FirstPage : Framework.Navigation.CitoNavigationPage
    {
        public FirstPage()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await CitoNavigation.PushPage(new Framework.Navigation.SecondPage());
        }
    }
}
