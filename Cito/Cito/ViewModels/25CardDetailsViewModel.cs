using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Cito.Views;
using Xamarin.Forms;

namespace Cito.ViewModels
{
    public class CardDetailsViewModel : CitoViewModelBase
    {

        public ICommand SubmitDetailsCommand => new Command(async () => await GoToPage(new OrderDetailsPage()));
    }
}
