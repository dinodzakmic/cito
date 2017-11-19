using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cito.ViewModels
{
    public class PromoCodeViewModel : CitoViewModelBase
    {
        #region Bindable properties

        private string _promoCode;

        public string PromoCode
        {
            get { return _promoCode; }
            set { Set(ref _promoCode, value); }
        }

        #endregion
        #region Commands
        public ICommand UsePromoCodeCommand { get; private set; }

        private void SetCommands()
        {
            UsePromoCodeCommand = new Command(async () => await UsePromoCode());
        }
        #endregion

        public PromoCodeViewModel()
        {
            SetCommands();
        }

        #region Methods
        private async Task UsePromoCode()
        {
            try
            {
                await App.NavPage.DisplayAlert("Promo code", "Promo code " + PromoCode + " was used successfully!", "OK");
            }
            catch (Exception e)
            {
                // ignored
            }
        }
        #endregion
    }
}
