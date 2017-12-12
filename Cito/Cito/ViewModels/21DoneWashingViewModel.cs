using System.Diagnostics;
using System.Threading.Tasks;
using Cito.Views;

namespace Cito.ViewModels
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows.Input;

    using Plugin.Media;

    using Xamarin.Forms;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    public class DoneWashingViewModel : CitoViewModelBase
    {

        public DoneWashingViewModel()
        {
            this.DoneWashingIndicatorColor = Color.Transparent;
        }

        private ImageSource photo;

        public ImageSource Photo
        {
            get
            {
                try
                {
                    return photo;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            set { Set(ref photo, value); }
        }

        private bool _photoTaken;

        public bool PhotoTaken
        {
            get { return _photoTaken; }
            set { Set(ref _photoTaken, value); }
        }

        private bool doneWashing;

        public bool DoneWashing
        {
            get { return this.doneWashing; }
            set { Set(ref this.doneWashing, value); }
        }

        private Color doneWashingIndicatorColor;

        public Color DoneWashingIndicatorColor
        {
            get { return this.doneWashingIndicatorColor; }
            set { Set(ref this.doneWashingIndicatorColor, value); }
        }

        public ICommand DoneWashingCommand
        {
            get
            {
                return new Command(() =>
                    {
                        this.DoneWashing = true;
                        this.DoneWashingIndicatorColor = Color.FromHex("26a4ad");
                    });
            }
        }


        public ICommand DoneCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        //await App.NavPage.CurrentPage.DisplayAlert("Success",
                        //    "Great job. Thank you for using Cito. Keep going", "OK");

                        await GoToPage(new AfterWashingPage());
                        
                        Device.StartTimer(TimeSpan.FromSeconds(3), () =>
                        {
                            Device.BeginInvokeOnMainThread(async () => await GoToRootPage());
                            PhotoTaken = false;
                            DoneWashing = false;
                            Photo = null;
                            return false;
                        });
                        
                    }
                    catch (Exception e)
                    {
                        await App.NavPage.CurrentPage.DisplayAlert("Error", e.Message, "OK");
                    }
                    
                });
            }
        }

        public ICommand GoToPhotoPageCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await this.GoToPage(new DoneWashingPhotoPage());
                    this.TakePhoto();
                });
            }
        }

        public ICommand TakePhotoCommand
        {
            get { return new Command(TakePhoto); }
        }

        public async void TakePhoto() // takePhoto.Clicked += async(sender, args) =>
        {
            try
            {
                if (!DoneWashing)
                {
                    return;
                }

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
                    Photo = src;
                    PhotoTaken = true;
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
    }
}
