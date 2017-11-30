using System.Xml.Schema;
using Foundation;
using Google.SignIn;
using ImageCircle.Forms.Plugin.iOS;
using UIKit;

namespace Cito.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Facebook.CoreKit.Settings.AppID = "1454486721332127";
            Facebook.CoreKit.Settings.DisplayName = "Cito";

            SignIn.SharedInstance.ClientID = "867076694592-sgqvmuqgqtbqpedrscasbq3mhong5n97.apps.googleusercontent.com";       

            global::Xamarin.Forms.Forms.Init();

            UINavigationBar.Appearance.SetBackgroundImage(UIImage.FromFile("NavigationBarGradient.jpg"), UIBarPosition.Top,
                UIBarMetrics.Default);
            UINavigationBar.Appearance.BarTintColor = UIColor.White;
            UINavigationBar.Appearance.TintColor = UIColor.White;

            System.Net.ServicePointManager.DnsRefreshTimeout = 0;
            Xamarin.FormsMaps.Init();
            ImageCircleRenderer.Init();
            LoadApplication(new App());
            
            return base.FinishedLaunching(app, options);
        }

        public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
        {
            if (FacebookLogin.IsFacebookLogin)
            {
                FacebookLogin.IsFacebookLogin = false;
                return Facebook.CoreKit.ApplicationDelegate.SharedInstance.OpenUrl(application, url, sourceApplication,
                    annotation);
            }
            if (GoogleLogin.IsGoogleLogin)
            {
                GoogleLogin.IsGoogleLogin = false;
                return SignIn.SharedInstance.HandleUrl(url, sourceApplication, annotation);
            }

            return false;
        }

        public override void OnActivated(UIApplication uiApplication)
        {
            base.OnActivated(uiApplication);
            Facebook.CoreKit.AppEvents.ActivateApp();
        }
    }
}
