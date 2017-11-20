using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cito.Models
{
    public class PastWashes
    {
        public string Month { get; set; }
        public List<PastWashDetails> Washes { get; set; }
        public Color BackgroundColor { get; set; }

        public PastWashes(string month, List<PastWashDetails> washers = null)
        {
            Month = month;
            Washes = washers ?? new List<PastWashDetails>();
            BackgroundColor = Washes.Any() 
                ? (Color) Application.Current.Resources["CitoDarkBackground"] 
                : Color.Transparent ;
        }
    }
}
