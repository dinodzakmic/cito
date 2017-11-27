using Cito.Framework.Components;
using Cito.iOS.Renderers;
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
                    FacebookLogin.IsFacebookLogin = true;
                    FacebookLogin.HandleFacebookLoginClicked();
                };
                                                       
            }
            else if (externalLogin == ImageButton.Social.Google)
            {

                citoButton.Clicked += delegate
                {
                    GoogleLogin.IsGoogleLogin = true;
                    GoogleLogin.HandleGoogleLoginClicked();
                };
            }
            else
            {
                return;
            }
        }

        
    }
}
