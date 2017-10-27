using System.Collections.Generic;
using GalaSoft.MvvmLight;
using Xamarin.Forms.Maps;

namespace Cito.ViewModels
{    
    public class MainViewModel : ViewModelBase
    {
        public List<Pin> CitoPins => new List<Pin>()
        {
            new Pin()
            {
                Position = new Position(44,18),
                Label = "Test Pin"
            }
        };
        public MainViewModel()
        {
            
        }
    }
}