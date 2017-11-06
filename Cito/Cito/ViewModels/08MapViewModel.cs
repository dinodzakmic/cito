using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                Position = new Position(25.790942, -80.215823)
            }
        };

        public Position CurrentUserPosition => new Position(25.790942, -80.215823);
    }
}
