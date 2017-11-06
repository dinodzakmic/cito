using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
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
                    if (AccessToken.CurrentAccessToken != null)
                    {
                        LoginManager.Instance.LogOut();
                        FacebookLogin.LoginCallback.OnLogout();
                    }
                    else
                    {
                        facebookLoginButton.PerformClick();
                    }

                };
            }
            else if (externalLogin == ImageButton.Social.Google)
            {
                citoButton.Clicked += async (sender, args) =>
                {
                    await App.NavPage.DisplayAlert("TODO", "TODO", "OK");
                };
                return;
            }
            else
            {
                return;
            }
        }
    }
}