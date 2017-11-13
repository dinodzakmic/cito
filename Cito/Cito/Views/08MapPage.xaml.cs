using System;
using Xamarin.Forms;

namespace Cito.Views
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
        }

        public Color SelectedColor => (Color)Application.Current.Resources["CitoMain"];
        private void StandardTapped(object sender, EventArgs e)
        {
            Standard.BackgroundColor = SelectedColor;
            Professional.BackgroundColor = Color.Transparent;
            Elite.BackgroundColor = Color.Transparent;
        }

        private void ProfessionalTapped(object sender, EventArgs e)
        {
            Standard.BackgroundColor = Color.Transparent;
            Professional.BackgroundColor = SelectedColor;
            Elite.BackgroundColor = Color.Transparent;
        }

        private void EliteTapped(object sender, EventArgs e)
        {
            Standard.BackgroundColor = Color.Transparent;
            Professional.BackgroundColor = Color.Transparent;
            Elite.BackgroundColor = SelectedColor;
        }
    }
}
