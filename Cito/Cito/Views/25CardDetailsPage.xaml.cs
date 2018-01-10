using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cito.Framework.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cito.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardDetailsPage : ContentPage
    {
        public CardDetailsPage()
        {
            InitializeComponent();
        }

        private void CardNumber_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is CitoEntry entry && entry.Text.Length == 4)
                entry.NextView?.Focus();
        }
    }
}