using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cito.Models
{
    public class FutureWashes
    {
        public string Month { get; set; }
        public List<FutureWashDetails> Washes { get; set; }
        public Color BackgroundColor { get; set; }

        public FutureWashes(string month, List<FutureWashDetails> washers = null)
        {
            Month = month;
            Washes = washers ?? new List<FutureWashDetails>();
            BackgroundColor = Washes.Any()
                ? (Color)Application.Current.Resources["CitoDarkBackground"]
                : Color.Transparent;
        }
    }
}
