using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cito.Models
{
    public class PastWashes
    {
        public string Month { get; set; }
        public List<PastWasherDetails> Washers { get; set; }

        public PastWashes(string month, List<PastWasherDetails> washers = null)
        {
            Month = month;
            Washers = washers ?? new List<PastWasherDetails>();
        }
    }
}
