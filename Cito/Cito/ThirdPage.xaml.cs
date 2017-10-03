using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Cito
{
    public partial class ThirdPage : ContentPage
    {
        public ThirdPage()
        {
            InitializeComponent();
            
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            if (App.FormValidationPassed())
                DisplayAlert("Success", "Success", "OK");
        }
    }
}
