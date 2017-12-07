using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Cito.Framework.Helpers;
using Cito.Framework.Utilities;
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

        private Position _currentUserPosition = new Position(CitoSettings.Current.LastLatitude, CitoSettings.Current.LastLongitude);
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


        public bool IsOwner => CitoSettings.Current.UserType.Equals(UserTypeViewModel.UserTypeOf.Owner.ToString());
        public bool IsWasher => CitoSettings.Current.UserType.Equals(UserTypeViewModel.UserTypeOf.Washer.ToString());
        public bool IsWasherAvailable => IsWasher && App.Locator.Availability.UserOnline;
        #endregion
        #region Commands
        public ICommand GoToCardDetailsCommand => new Command(async () => await GoToPage(new CardDetailsPage()));
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
                        Label = "Washer Name 1",
                        Address = "Washer Address 1",
                        Position = new Position(25.997987, -80.152303),
                        Type = PinType.Place
                    },
                    new Pin()
                    {
                        Label = "Washer Name 2",
                        Address = "Washer Address 2",
                        Position = new Position(25.743502, -80.232080),
                        Type = PinType.Place
                    },
                    new Pin()
                    {
                        Label = "Washer Name 3",
                        Address = "Washer Address 3",
                        Position = new Position(25.759817, -80.194273),
                        Type = PinType.Place
                    },
                    new Pin()
                    {
                        Label = "Washer Name 4",
                        Address = "Washer Address 4",
                        Position = new Position(25.717710, -80.276134),
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
