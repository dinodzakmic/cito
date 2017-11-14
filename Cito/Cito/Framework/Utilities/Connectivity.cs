using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Connectivity;

namespace Cito.Framework.Utilities
{
    public class Connectivity
    {
        public static bool IsConnectionAvailable => CrossConnectivity.Current.IsConnected;


    }
}
