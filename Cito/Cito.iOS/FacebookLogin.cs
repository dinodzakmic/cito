using System;
using System.Collections.Generic;
using System.Text;
using Facebook.CoreKit;
using Facebook.LoginKit;
using UIKit;

namespace Cito.iOS
{
    public static class FacebookLogin
    {
        internal static bool IsFacebookLogin;
        public static void HandleFacebookLoginClicked()
        {
            if (AccessToken.CurrentAccessToken != null)
            {
                App.Locator.Prelogin.ExternalLoginCommand.Execute(null);
            }
            else
            {
                var window = UIApplication.SharedApplication.KeyWindow;
                var vc = window.RootViewController;
                while (vc.PresentedViewController != null)
                {
                    vc = vc.PresentedViewController;
                }

                var manager = new LoginManager();
                manager.LogInWithReadPermissions(new string[] { "public_profile", "email" },
                    vc, (result, error) =>
                        {
                            if (error == null && !result.IsCancelled)
                            {
                                App.Locator.CreateAccount.FullName = Facebook.CoreKit.Profile.CurrentProfile.Name;
                                App.Locator.Prelogin.ExternalLoginCommand.Execute(null);
                            }
                        });
                
               
            }

            

        }
    }
}
