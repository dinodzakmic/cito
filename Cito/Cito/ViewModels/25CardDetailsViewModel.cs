using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Cito.Framework.Utilities;
using Cito.Views;
using Xamarin.Forms;

namespace Cito.ViewModels
{
    public class CardDetailsViewModel : CitoViewModelBase
    {
        #region Bindable properties
        #region CardNumber
        private string _cardNumberFirst;

        public string CardNumberFirst
        {
            get { return _cardNumberFirst; }
            set
            {
                if (value.Length > 4) return;
                Set(ref _cardNumberFirst, value);
            }
        }

        private string _cardNumberSecond;

        public string CardNumberSecond
        {
            get { return _cardNumberSecond; }
            set
            {
                if (value.Length > 4) return;
                Set(ref _cardNumberSecond, value);
            }
        }

        private string _cardNumberThird;

        public string CardNumberThird
        {
            get { return _cardNumberThird; }
            set
            {
                if (value.Length > 4) return;
                Set(ref _cardNumberThird, value);
            }
        }

        private string _cardNumberFourth;
        

        public string CardNumberFourth
        {
            get { return _cardNumberFourth; }
            set
            {
                if (value.Length > 4) return;
                Set(ref _cardNumberFourth, value);
            }
        }


        public string CardNumberFull => CardNumberFirst + CardNumberSecond + CardNumberThird + CardNumberFourth;

        public string MaskedCardNumber => StringHelpers.MaskCardNumber(CardNumberFull);
        #endregion
        #region CardExpiry
        private string _expiryMonth;
        public string ExpiryMonth
        {
            get { return _expiryMonth; }
            set { Set(ref _expiryMonth, value); }
        }

        private string _expiryYear;
        public string ExpiryYear
        {
            get { return _expiryYear; }
            set { Set(ref _expiryYear, value); }
        }

        #endregion
        #region CardHolder
        private string _cardHolder;
        public string CardHolder
        {
            get { return _cardHolder; }
            set { Set(ref _cardHolder, value); }
        }

        #endregion
        #region CvvNumber
        private string _cvvNumber;
        public string CvvNumber
        {
            get { return _cvvNumber; }
            set { Set(ref _cvvNumber, value); }
        }
        #endregion
        #endregion

        #region Commands

        public ICommand SubmitDetailsCommand => new Command(async () => await SubmitDetails());

        #endregion

        #region Methods

        private async Task SubmitDetails()
        {
            try
            {
                if (string.IsNullOrEmpty(CardNumberFirst) || string.IsNullOrEmpty(CardNumberSecond) || string.IsNullOrEmpty(CardNumberThird) || string.IsNullOrEmpty(CardNumberFourth))
                {
                    await App.NavPage.CurrentPage.DisplayAlert("Error", "Please enter valid card number", "OK");
                    return;
                }
                if (string.IsNullOrEmpty(CardHolder))
                {
                    await App.NavPage.CurrentPage.DisplayAlert("Error", "Please enter cardholder name", "OK");
                    return;
                }
                if (string.IsNullOrEmpty(ExpiryMonth) || string.IsNullOrEmpty(ExpiryYear))
                {
                    await App.NavPage.CurrentPage.DisplayAlert("Error", "Please enter valid card expiry", "OK");
                    return;
                }
                if (string.IsNullOrEmpty(CvvNumber))
                {
                    await App.NavPage.CurrentPage.DisplayAlert("Error", "Please enter CVV number", "OK");
                    return;
                }

                var expiryMonth = int.Parse(ExpiryMonth);
                var expiryYear = int.Parse(ExpiryYear);

                if (expiryMonth < 1 || expiryMonth > 12)
                {
                    await App.NavPage.CurrentPage.DisplayAlert("Error", "Please enter valid month", "OK");
                    return;
                }

                if (expiryYear < 17)
                {
                    await App.NavPage.CurrentPage.DisplayAlert("Error", "Please enter valid year", "OK");
                    return;
                }


                await GoToPage(new OrderDetailsPage());
            }
            catch (Exception e)
            {
                // ignored
            }
        }
        #endregion
    }
}
