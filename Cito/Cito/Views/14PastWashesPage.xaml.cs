﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Cito.Views
{
    public partial class PastWashesPage : ContentPage
    {
        public PastWashesPage()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await App.NavPage.PushAsync(new OwnerProfilePage());
        }
    }
}
