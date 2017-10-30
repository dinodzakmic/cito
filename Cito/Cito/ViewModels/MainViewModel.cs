using System.Collections.Generic;
using GalaSoft.MvvmLight;
using Xamarin.Forms.Maps;

namespace Cito.ViewModels
{    
    public class MainViewModel : CitoViewModelBase
    {
        public List<Pin> CitoPins => new List<Pin>()
        {
            new Pin()
            {
                Position = new Position(44,18),
                Label = "Test Pin",
                Address = "Neka adresa"
            }
        };

        public int MyRating => 1;
        public MainViewModel()
        {
            
        }
    }
}