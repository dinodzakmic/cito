using GalaSoft.MvvmLight;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Cito.Framework.Helpers
{
    public class CitoSettings : ObservableObject
    {
        static ISettings AppSettings => CrossSettings.Current;

        static CitoSettings _settings;
        public static CitoSettings Current => _settings ?? (_settings = new CitoSettings());

        #region Settings Constants
        const string FullNameKey = "8bbl8d25256d18odhyhseb338db3a";
        static readonly string FullNameDefault = "";

        const string CarModelKey = "8bbl8d25256d18odhyhseb442db3a";
        static readonly string CarModelDefault = "";

        const string IsUserLoggedInKey = "7aaf7d31316d18odhyhseb338db3a";
        static readonly bool IsUserLoggedInDefault = false;

        const string UserTypeKey = "8bbl8d31316d18odhyhseb338db3a";
        static readonly string UserTypeDefault = "Owner";

        const string LastLatitudeKey = "3bbl3d31311d18odhyhmen338db3a";
        static readonly double LastLatitudeDefault = 0;

        const string LastLongitudeKey = "1bbl1d31311d18odhyhmen338db1b";
        static readonly double LastLongitudeDefault = 0;
        #endregion

        public string FullName
        {
            get
            {
                return AppSettings.GetValueOrDefault(FullNameKey, FullNameDefault);
            }
            set
            {
                if (AppSettings.AddOrUpdateValue(FullNameKey, value))
                    RaisePropertyChanged(() => FullName);
            }
        }

        public string CarModel
        {
            get
            {
                return AppSettings.GetValueOrDefault(CarModelKey, CarModelDefault);
            }
            set
            {
                if (AppSettings.AddOrUpdateValue(CarModelKey, value))
                    RaisePropertyChanged(() => CarModel);
            }
        }

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
