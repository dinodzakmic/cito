using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Auth.Api.SignIn;
using Android.Gms.Common;
using Android.Gms.Common.Apis;
using Android.Gms.Common.Internal;
using Android.Gms.Plus;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Cito.Droid.Renderers;
using Xamarin.Facebook;
using Xamarin.Facebook.Login;
using Xamarin.Facebook.Login.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Button = Xamarin.Forms.Button;
using View = Xamarin.Forms.View;
using ImageButton = Cito.Framework.Components.ImageButton;
using Object = Java.Lang.Object;

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