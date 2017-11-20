using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cito.Models
{
    public class FutureWashDetails
    {
        public string CarImage { get; set; }
        public string Date { get; set; }
        public string Car { get; set; }
        public string WashingPackage { get; set; }
        public string CardNumber { get; set; }

        public FutureWashDetails(string carImage, string date, string car, string washingPackage, string cardNumber)
        {
            CarImage = carImage;
            Date = date;
            Car = car;
            WashingPackage = washingPackage;
            CardNumber = cardNumber;
        }
    }
}
