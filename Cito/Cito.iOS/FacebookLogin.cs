using System;
using System.Collections.Generic;
using System.Text;
using Facebook.CoreKit;
using Facebook.LoginKit;
using Foundation;
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
                manager.LogInWithReadPermissions(new string[] { "public_profile", "email" }, vc, (result, error) => {
                    if (error == null && !result.IsCancelled)
                    {
						if (Profile.CurrentProfile != null && Profile.CurrentProfile.Name != null) {
							App.Locator.CreateAccount.FullName = Facebook.CoreKit.Profile.CurrentProfile.Name;
							App.Locator.Prelogin.ExternalLoginCommand.Execute(null);
						} else {
							if (result.Token != null) {
								var graphRequest = new GraphRequest("/me", null, "GET");
								var graphConnection = new GraphRequestConnection();
								graphConnection.AddRequest(graphRequest, (connection, fbResult, fbError) => {
									if (fbError == null) {
										try {
											var res = (NSDictionary)fbResult;
											App.Locator.CreateAccount.FullName = res["name"].ToString();
											App.Locator.Prelogin.ExternalLoginCommand.Execute(null);
										} catch (Exception) {
											App.Current.MainPage.DisplayAlert("Error", "Something went wrong", "OK");
										}
									}
								});
								graphConnection.Start();
							}
						}
                    }
                });
                
               
            }

            

        }
    }
}
