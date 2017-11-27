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
        private List<Pin> _pinList = new List<Pin>();
        public List<Pin> PinList
        {
            get { return _pinList; }
            set { Set(ref _pinList, value); }
        }
        public Position CurrentUserPosition => new Position(CitoSettings.Current.LastLatitude, CitoSettings.Current.LastLongitude);

        private Package _washerPackage;
        
        public Package WasherPackage
        {
            get { return _washerPackage; }
            set { Set(ref _washerPackage, value); }
        }


        public bool IsOwner => CitoSettings.Current.UserType.Equals(UserTypeViewModel.UserTypeOf.Owner.ToString());
        public bool IsWasher => CitoSettings.Current.UserType.Equals(UserTypeViewModel.UserTypeOf.Washer.ToString());
        public bool IsWasherAvailable => IsWasher && App.Locator.Availability.UserOnline;
        #endregion
        #region Commands
        public ICommand GoToOrderDetailsCommand => new Command(async () => await GoToOrderDetails());
        public ICommand GoToWashingRequestsCommand => new Command(async () => await GoToWashingRequests());


        #endregion

        public MapViewModel()
        {
            if (IsOwner)
            {
                PinList = new List<Pin>()
                {
                    new Pin()
                    {
                        Label = "Washer Name",
                        Address = "Washer Address",
                        Position = new Position(25.790942, -80.215823),
                        Type = PinType.Place
                    }
                };
            }
        }

        #region Methods
        private async Task GoToOrderDetails()
        {
            await GoToPage(new OrderDetailsPage());
        }
        private async Task GoToWashingRequests()
        {
            await GoToPage(new WashingRequestsPage());
        }
        #endregion
    }
}