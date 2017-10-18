using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Cito
{
    public partial class CreateAccountPage : ContentPage
    {
        public CreateAccountPage(bool externalLoginFirstTime = false, bool signIn = false)
        {
            InitializeComponent();
            if (externalLoginFirstTime && signIn) return;

            if (externalLoginFirstTime)
            {
                EmailEntry.IsVisible = false;
                CarModelEntry.NextView = NumberEntry;

                PasswordEntry.IsVisible = false;
                NumberEntry.NextView = null;
            }
            if (signIn)
            {
                CarModelEntry.IsVisible = false;
                FullNameEntry.NextView = EmailEntry;
            }
                      
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new UserTypePage();            
        }
    }
}

