using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Cito
{
    public partial class FirstPage : ContentPage
    {
        public FirstPage()
        {
            InitializeComponent();
        }

        //Test
        private void Button_OnClicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new SecondPage();
        }
    }
}
