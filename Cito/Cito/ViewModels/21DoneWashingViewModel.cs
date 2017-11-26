using System.Threading.Tasks;
using Cito.Views;

namespace Cito.ViewModels
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows.Input;

    using Plugin.Media;

    using Xamarin.Forms;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    public class DoneWashingViewModel : CitoViewModelBase
    {

        private ImageSource photo;

        public ImageSource Photo
        {
            get { return photo; }
            set { Set(ref photo, value); }
        }

        private bool _photoTaken;

        public bool PhotoTaken
        {
            get { return _photoTaken; }
            set { Set(ref _photoTaken, value); }
        }
        
        public ICommand DoneCommand => new Command(async () =>
        {
            await GoToRootPage();
            PhotoTaken = false;
        });
        public ICommand GoToPhotoPageCommand => new Command(async () => await GoToPage(new DoneWashingPhotoPage()));

        public ICommand TakePhotoCommand => new Command(async () => await TakePhoto());
        public async Task TakePhoto()// takePhoto.Clicked += async(sender, args) =>

        {

            await CrossMedia.Current.Initialize();
    
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                //DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var x = new Plugin.Media.Abstractions.StoreCameraMediaOptions();

            var file = await CrossMedia.Current.TakePhotoAsync(x);

            if (file == null)
                return;

            //await DisplayAlert("File Location", file.Path, "OK");

            var src = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });

            if (src != null)
            {
                Photo = src;
                PhotoTaken = true;
            }

            //or:
            //image.Source = ImageSource.FromFile(file.Path);
            //image.Dispose();
            
        }
    }
}
