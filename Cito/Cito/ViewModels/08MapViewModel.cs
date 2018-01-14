using System;
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
         
        private bool _scheduleWashingEnabled = false;
        public bool ScheduleWashingEnabled
        {
            get { return _scheduleWashingEnabled; }
            set { Set(ref _scheduleWashingEnabled, value); }
        }

        private DateTime _selectedDate = DateTime.Now;

        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                Set(ref _selectedDate, value);
                RaisePropertyChanged(() => SelectedDateString);
            }
        }

        public string SelectedDateString => SelectedDate.ToString("d");

        private TimeSpan _selectedTime = DateTime.Now.TimeOfDay.Add(TimeSpan.FromMinutes(30));
        

        public TimeSpan SelectedTime
        {
            get { return _selectedTime; }
            set
            {
                Set(ref _selectedTime, value);
                RaisePropertyChanged(() => SelectedTimeString);
            }
        }

        public string SelectedTimeString => SelectedTime.ToString("hh\\:mm");


        public bool IsOwner => CitoSettings.Current.UserType.Equals(UserTypeViewModel.UserTypeOf.Owner.ToString());
        public bool IsWasher => CitoSettings.Current.UserType.Equals(UserTypeViewModel.UserTypeOf.Washer.ToString());
        public bool IsWasherAvailable => IsWasher && App.Locator.Availability.UserOnline;
        #endregion
        #region Commands
        public ICommand GoToScheduleOrderCommand => new Command(async () => await GoToPage(new ScheduleOrderPage()));
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
                        Position = new Position(this.CurrentUserPosition.Latitude + 0.25, this.CurrentUserPosition.Longitude),
                        Type = PinType.Place
                    },
                    new Pin()
                    {
                        Label = "Washer Name 2",
                        Address = "Washer Address 2",
                        Position = new Position(this.CurrentUserPosition.Latitude, this.CurrentUserPosition.Longitude -0.1234),
                        Type = PinType.Place
                    },
                    new Pin()
                    {
                        Label = "Washer Name 3",
                        Address = "Washer Address 3",
                        Position = new Position(this.CurrentUserPosition.Latitude + 0.21, this.CurrentUserPosition.Longitude+0.3),
                        Type = PinType.Place
                    },
                    new Pin()
                    {
                        Label = "Washer Name 4",
                        Address = "Washer Address 4",
                        Position = new Position(this.CurrentUserPosition.Latitude + 1, this.CurrentUserPosition.Longitude-1),
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
