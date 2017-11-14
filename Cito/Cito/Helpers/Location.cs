using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace Cito.Helpers
{
    public static class Location
    {
        public static Position CurrentPosition { get; set; }
    }
}
