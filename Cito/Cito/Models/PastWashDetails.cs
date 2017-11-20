using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cito.Models
{
    public class PastWashDetails
    {
        public string WasherImage { get; set; }
        public string WasherName { get; set; }
        public int WasherRating { get; set; }
        public string Price { get; set; }

        public PastWashDetails(string washerImage, string washerName, int washerRating, string price)
        {
            WasherImage = washerImage;
            WasherName = washerName;
            WasherRating = washerRating;
            Price = price;
        }
    }
}
