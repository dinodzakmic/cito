using Android.Gms.Common;
using Cito.Droid.Renderers;
using Cito.Framework.Utilities;
using Xamarin.Facebook.Login.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ImageButton = Cito.Framework.Components.ImageButton;

[assembly: ExportRenderer(typeof(ImageButton), typeof(ImageButtonRenderer))]
namespace Cito.Droid.Renderers
{
    internal class ImageButtonRenderer : ViewRenderer<ImageButton, Android.Views.View>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ImageButton> e)
        {
            base.OnElementChanged(e);

            var citoButton = e.NewElement.CitoButton;
            if (citoButton == null) return;

            var externalLogin = e.NewElement.ExternalLogin; 
                       
            if (externalLogin == ImageButton.Social.Facebook)
            {
                var facebookLoginButton = new LoginButton(Forms.Context);
                facebookLoginButton.SetReadPermissions(new string[] { "public_profile", "email" });

                citoButton.Clicked += (sender, args) =>
                {
                    if (!Connectivity.CheckConnectionAndDisplayToast())
                        return;

                    if (FacebookLogin.FacebookLoggedIn)
                    {
                        App.Locator.Prelogin.ExternalLoginCommand.Execute(null);
                        return;
                    }

                    facebookLoginButton.PerformClick();
                    FacebookLogin.IsFacebookLogin = true;                   
                };
            }
            else if (externalLogin == ImageButton.Social.Google)
            {               
                var googleLoginButton = new SignInButton(Forms.Context);                
                citoButton.Clicked += (sender, args) =>
                {
                    if (!Connectivity.CheckConnectionAndDisplayToast())
                        return;

                    googleLoginButton.PerformClick();
                    if (GoogleLogin.MyGoogleApiClient.IsConnecting) return;

                    GoogleLogin.MyGoogleApiClient.Reconnect();
                    GoogleLogin.IsGoogleLogin = true;
                    GoogleLogin.IntentHandled = true;
                };
            }
            else
            {
                return;
            }
        }       
    }

}