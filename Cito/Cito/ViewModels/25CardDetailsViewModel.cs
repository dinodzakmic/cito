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

        #region Commands

        public ICommand SubmitDetailsCommand => new Command(async () => await GoToPage(new OrderDetailsPage()));

        #endregion

        #region Methods

        #endregion
    }
}
