using System;
using System.Collections.Generic;
using System.Text;
using Cito.Framework.Components;
using Cito.Framework.Utilities;
using Cito.iOS.Renderers;
using Facebook.CoreKit;
using Facebook.LoginKit;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ImageButton), typeof(ImageButtonRenderer))]
namespace Cito.iOS.Renderers
{
    internal class ImageButtonRenderer : ViewRenderer<ImageButton, UIView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ImageButton> e)
        {
            base.OnElementChanged(e);

            var citoButton = e.NewElement.CitoButton;
            if (citoButton == null) return;

            var externalLogin = e.NewElement.ExternalLogin;

            if (externalLogin == ImageButton.Social.Facebook)
            {
                citoButton.Clicked += delegate
                {
                    FacebookLogin.HandleFacebookLoginClicked();
                };
                                                       
            }
            else if (externalLogin == ImageButton.Social.Google)
            {
               
            }
            else
            {
                return;
            }
        }

        
    }
}
