using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cito.Models
{
    public class Package
    {
        public enum PackageType
        {
            Standard,
            Professional,
            Elite
        }

        public PackageType SelectedPackage { get; set; }
        public string PackageName { get; set; }
        public string PackagePrice { get; set; }

        public Package(PackageType selectedPackage, string packageName, string packagePrice)
        {
            SelectedPackage = selectedPackage;
            PackageName = packageName;
            PackagePrice = packagePrice;
        }

        public Package()
        {
            
        }

        //fake
        public static Package StandardPackage = new Package(PackageType.Standard, "Standard Pack" , "12.99$");
        public static Package ProfessionalPackage = new Package(PackageType.Professional, "Professional Pack" , "24.99$");
        public static Package ElitePackage = new Package(PackageType.Elite, "Elite Pack" , "39.99$");
        public static List<Package> ReturnDefaultPackages()
        {
            return new List<Package>()
            {
               StandardPackage, ProfessionalPackage, ElitePackage
            };
        }
    }
}
