using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace Cito.ViewModels
{
    public class OwnerProfileViewModel : ViewModelBase
    {
        public string FullName => "John Doe";
        public OwnerProfileViewModel()
        {
           
        }
    }
}
