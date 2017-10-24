using System;
using System.Diagnostics;

namespace Cito.Framework.Navigation
{
    public partial class SecondPage : Framework.Navigation.CitoNavigationPage
    {
        public SecondPage()
        {
            InitializeComponent();
        }

        private async void GoToCito(object sender, EventArgs e)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            await CitoNavigation.PushPage(new ThirdPage());
            stopwatch.Stop();
            Debug.WriteLine("Cito navigation: " + stopwatch.ElapsedMilliseconds);
        }
    }
}
