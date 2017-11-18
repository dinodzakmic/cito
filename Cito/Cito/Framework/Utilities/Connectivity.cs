using System;
using Acr.UserDialogs;
using Plugin.Connectivity;

namespace Cito.Framework.Utilities
{
    public class Connectivity
    {
        internal static bool ShouldCheckConnection = true;

        public static bool IsConnectionAvailable => CrossConnectivity.Current.IsConnected;
        public static bool CheckConnectionAndDisplayToast()
        {
            if (!ShouldCheckConnection)
                return true;

            if (!IsConnectionAvailable)
            {
                UserDialogs.Instance.Toast("Please check your internet connection", TimeSpan.FromSeconds(2));
                return false;
            }

            return true;
        }

    }
}
