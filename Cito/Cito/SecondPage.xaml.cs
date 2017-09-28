using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Cito
{
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();
        }


        //Test

        private void Button_OnClicked1(object sender, EventArgs e)
        {
            App.Current.MainPage = new FirstPage();
        }
        private void Button_OnClicked2(object sender, EventArgs e)
        {
            App.Current.MainPage = new ThirdPage();
        }

       
    }
}
