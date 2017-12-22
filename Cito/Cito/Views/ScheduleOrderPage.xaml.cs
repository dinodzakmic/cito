using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cito.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ScheduleOrderPage : ContentPage
	{
		public ScheduleOrderPage ()
		{
			InitializeComponent ();
		}

	    private void PickerDateButton(object sender, EventArgs e)
	    {
	        PickerDate.Focus();
	    }

	    private void PickerTimeButton(object sender, EventArgs e)
	    {
	        PickerTime.Focus();
	    }
	}
}