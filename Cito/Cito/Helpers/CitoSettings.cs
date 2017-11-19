using GalaSoft.MvvmLight;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Cito.Helpers
{
    public class CitoSettings : ObservableObject
    {
        static ISettings AppSettings => CrossSettings.Current;

        static CitoSettings _settings;
        public static CitoSettings Current => _settings ?? (_settings = new CitoSettings());

        #region Settings Constants
        const string IsUserLoggedInKey = "7aaf7d31316d18odhyhseb338db3a";
        static readonly bool IsUserLoggedInDefault = false;

        const string UserTypeKey = "8bbl8d31316d18odhyhseb338db3a";
        static readonly string UserTypeDefault = "Owner";

        const string LastLatitudeKey = "3bbl3d31311d18odhyhmen338db3a";
        static readonly double LastLatitudeDefault = 0;

        const string LastLongitudeKey = "1bbl1d31311d18odhyhmen338db1b";
        static readonly double LastLongitudeDefault = 0;
        #endregion


        public bool IsUserLoggedIn
        {
            get
            {
                return AppSettings.GetValueOrDefault(IsUserLoggedInKey, IsUserLoggedInDefault);
            }
            set
            {
                if (AppSettings.AddOrUpdateValue(IsUserLoggedInKey, value))
                    RaisePropertyChanged(() => IsUserLoggedIn);
            }
        }

        public string UserType
        {
            get
            {
                return AppSettings.GetValueOrDefault(UserTypeKey, UserTypeDefault);
            }
            set
            {
                if (AppSettings.AddOrUpdateValue(UserTypeKey, value))
                    RaisePropertyChanged(() => UserType);
            }
        }

        public double LastLatitude
        {
            get
            {
                return AppSettings.GetValueOrDefault(LastLatitudeKey, LastLatitudeDefault);
            }
            set
            {
                if (AppSettings.AddOrUpdateValue(LastLatitudeKey, value))
                    RaisePropertyChanged(() => LastLatitude);
            }
        }

        public double LastLongitude
        {
            get
            {
                return AppSettings.GetValueOrDefault(LastLongitudeKey, LastLongitudeDefault);
            }
            set
            {
                if (AppSettings.AddOrUpdateValue(LastLongitudeKey, value))
                    RaisePropertyChanged(() => LastLongitude);
            }
        }
    }
}
