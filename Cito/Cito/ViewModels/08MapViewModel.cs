using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cito.Helpers;
using Xamarin.Forms.Maps;

namespace Cito.ViewModels
{
    public class MapViewModel : CitoViewModelBase
    {
        public List<Pin> PinList => new List<Pin>()
        {
            new Pin()
            {
                Address = "Washer",
                Label = "Washer",
                Position = new Position(25.790942, -80.215823),
                Type = PinType.Place
            }
        };

        private Position _currentUserPosition =
            new Position(CitoSettings.Current.LastLatitude, CitoSettings.Current.LastLongitude);

        public Position CurrentUserPosition
        {
            get { return _currentUserPosition; }
            set { Set(ref _currentUserPosition, value); }
        } 
    }
}
