using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Cito.Framework.Helpers;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms;

namespace Cito.Framework.Utilities
{
    public static class Location
    {
        public static Position CurrentPosition { get; set; }
        internal static bool GpsStarted { get; set; } = false;

        public static async Task GetUserLocation()
        {
            if (!CrossGeolocator.Current.IsGeolocationEnabled && CitoSettings.Current.IsUserLoggedIn)
            {
                UserDialogs.Instance.Toast("Please enable your GPS for better experience", TimeSpan.FromSeconds(4));
                return;
            }

            try
            {
                await CrossGeolocator.Current.GetPositionAsync(TimeSpan.FromSeconds(5)).ContinueWith(t =>
                {
                    if (t.IsCompleted)
                    {
                        CurrentPosition = t.Result;
                        HandleCurrentPosition();
                    }
                });
            }
            catch (Exception e)
            {
                // ignored
            }
        }

        public static void StopGps()
        {
            //handle this
        }

        private static void HandleCurrentPosition()
        {
            CitoSettings.Current.LastLatitude = CurrentPosition.Latitude;
            CitoSettings.Current.LastLongitude = CurrentPosition.Longitude;
            App.Locator.Map.CurrentUserPosition = new Xamarin.Forms.Maps.Position(CitoSettings.Current.LastLatitude, CitoSettings.Current.LastLongitude);
        }
    }
}
