using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cito.ViewModels
{
    public class SupportViewModel : CitoViewModelBase
    {
        #region Bindable properties

        private string _messageText;

        public string MessageText
        {
            get { return _messageText; }
            set { Set(ref _messageText, value); }
        }
        #endregion

        #region Commands
        public ICommand AttachFileCommand { get; private set; }
        public ICommand SendMessageCommand { get; private set; }

        private void SetCommands()
        {
            AttachFileCommand = new Command(async () => await AttachFile());
            SendMessageCommand = new Command(async () => await SendMessage());
        }

        
        

        #endregion

        public SupportViewModel()
        {
            SetCommands();
        }

        #region Methods
        private async Task AttachFile()
        {
            try
            {
                await App.NavPage.DisplayAlert("TODO", "TODO", "OK");
            }
            catch (Exception e)
            {
                // ignored
            }
        }
        private async Task SendMessage()
        {
            try
            {
                await App.NavPage.DisplayAlert("TODO", "TODO", "OK");
            }
            catch (Exception e)
            {
                // ignored
            }
        }

        #endregion
    }
}
