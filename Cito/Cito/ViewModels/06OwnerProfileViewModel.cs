using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Cito.Framework.Helpers;
using GalaSoft.MvvmLight;
using Plugin.Media;
using Xamarin.Forms;

namespace Cito.ViewModels
{
    public class OwnerProfileViewModel : CitoViewModelBase
    {
        #region Bindable properties
        #region FullName

        public string FullName => CitoSettings.Current.FullName;
        #endregion
        #region CarsList

        private Car selectedCar;

        public Car SelectedCar
        {
            get => selectedCar;
            set
            {
                Set(ref selectedCar, value);
                if (value != null)
                {
                    index = CarsList.IndexOf(SelectedCar);
                }
            }
        }

        private int index;

        private Car editingCar;

        public Car EditingCar
        {
            get => editingCar;
            set => Set(ref editingCar, value);
        }

        private ObservableCollection<Car> _carsList;

        public ObservableCollection<Car> CarsList
        {
            get { return _carsList; }
            set { Set(ref _carsList, value); }
        }
        #endregion
        #endregion
        #region Commands

        public Command SaveEditCommand => new Command(() =>
        {
            CarsList.RemoveAt(index);
            CarsList.Insert(index, EditingCar);
            //this.SelectedCar.Model = this.EditingCar.Model;
            //this.SelectedCar.License = this.EditingCar.License;
            //this.SelectedCar.Picture = this.EditingCar.Picture;
            this.GoToPreviousPage();
            //this.SelectedCar = null;
        });

        public Command TakePhotoCommand => new Command(TakePhoto);
        #endregion

        public OwnerProfileViewModel()
        {
            var realCar = CitoSettings.Current.CarModel;
            CarsList = new ObservableCollection<Car>()
            {
                new Car(realCar,CitoSettings.Current.LicensePlate),
               // new Car("Toyota Corolla","DF 333444"),
            };
        }

        #region Methods

        public async void TakePhoto() // takePhoto.Clicked += async(sender, args) =>
        {
            try
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.IsSupported || !CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await App.NavPage.CurrentPage.DisplayAlert("Warning", "Camera is not available", "OK");
                    return;
                }

                App.IsCameraUsed = true;
                var x = new Plugin.Media.Abstractions.StoreCameraMediaOptions();
                App.UpdateLoading(false);
                await Task.Delay(200);
                var file = await CrossMedia.Current.TakePhotoAsync(x);

                if (file == null)
                {
                    return;
                }

                var src = ImageSource.FromFile(file.Path);
                if (src != null)
                {
                    EditingCar.Picture = src;
                    file.Dispose();
                }
            }
            catch (Exception e)
            {
                await App.NavPage.CurrentPage.DisplayAlert("Error", e.Message, "OK");
            }
            finally
            {
                App.IsCameraUsed = false;
                App.UpdateLoading(false);
            }
        }

        #endregion


        public class Car : ObservableObject
        {

            public Car(string model, string license, ImageSource picture = null)
            {
                this.Model = model;
                this.License = license;
                this.Picture = picture;
            }

            public Car(Car car)
            {
                this.Model = car.Model;
                this.License = car.License;
                this.Picture = car.Picture;
            }

            private string model;

            public string Model
            {
                get => model;
                set => Set(ref model, value);
            }

            private string license;

            public string License
            {
                get => license;
                set => Set(ref license, value);
            }

            private ImageSource picture;

            public ImageSource Picture
            {
                get => picture;
                set => Set(ref picture, value);
            }
        }
    }
}
