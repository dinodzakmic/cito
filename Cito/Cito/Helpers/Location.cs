using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms;

namespace Cito.Helpers
{
    public static class Location
    {
        public static Position CurrentPosition { get; set; }

        public static void GetUserLocation()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await CrossGeolocator.Current.GetPositionAsync().ContinueWith(t =>
                {
                    if (t.IsCompleted)
                    {
                        CurrentPosition = t.Result;
                        App.Locator.Map.CurrentUserPosition = new Xamarin.Forms.Maps.Position(Location.CurrentPosition.Latitude, Location.CurrentPosition.Longitude);

                        CitoSettings.Current.LastLatitude = Location.CurrentPosition.Latitude;
                        CitoSettings.Current.LastLongitude = Location.CurrentPosition.Longitude;
                    }
                });
            });
            

        }
    }
}
