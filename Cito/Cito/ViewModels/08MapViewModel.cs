﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Cito.Framework.Utilities;
using Cito.Helpers;
using Cito.Models;
using Cito.Views;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Cito.ViewModels
{
    public class MapViewModel : CitoViewModelBase
    {
        #region Bindable Properties
        public List<Pin> PinList => new List<Pin>()
        {
            new Pin()
            {
                Label = "Washer Name",
                Address = "Washer Address",
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

        private Package _washerPackage;

        public Package WasherPackage
        {
            get { return _washerPackage; }
            set { Set(ref _washerPackage, value); }
        }

        #endregion
        #region Commands
        public ICommand GoToOrderDetailsCommand => new Command(async () => await GoToOrderDetails());
        #endregion

        public MapViewModel()
        {
            Location.GetUserLocation();
        }

        #region Methods
        private async Task GoToOrderDetails()
        {
            await GoToPage(new OrderDetailsPage());
        }
        #endregion
    }
}
