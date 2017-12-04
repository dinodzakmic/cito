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

            var googleServiceDictionary = NSDictionary.FromFile("GoogleService-Info.plist");
            SignIn.SharedInstance.ClientID = googleServiceDictionary["CLIENT_ID"].ToString();

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


        //// For iOS 9 or newer
        //public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
        //{
        //    var openUrlOptions = new UIApplicationOpenUrlOptions(options);
        //    return SignIn.SharedInstance.HandleUrl(url, openUrlOptions.SourceApplication, openUrlOptions.Annotation);
        //}

        //// For iOS 8 and older
        //public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
        //{
        //    return SignIn.SharedInstance.HandleUrl(url, sourceApplication, annotation);
        //}



        //For iOS 9 or newer
        public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
        {
            if (FacebookLogin.IsFacebookLogin)
            {
                FacebookLogin.IsFacebookLogin = false;
                var openUrlOptions = new UIApplicationOpenUrlOptions(options);
                return Facebook.CoreKit.ApplicationDelegate.SharedInstance.OpenUrl(app, url, openUrlOptions.SourceApplication, openUrlOptions.Annotation);
            }
            if (GoogleLogin.IsGoogleLogin)
            {
                GoogleLogin.IsGoogleLogin = false;
                var openUrlOptions = new UIApplicationOpenUrlOptions(options);
                return SignIn.SharedInstance.HandleUrl(url, openUrlOptions.SourceApplication, openUrlOptions.Annotation);
            }

            return false;
        }


        //public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
        //{
        //    if (FacebookLogin.IsFacebookLogin)
        //    {
        //        FacebookLogin.IsFacebookLogin = false;
        //        return Facebook.CoreKit.ApplicationDelegate.SharedInstance.OpenUrl(application, url, sourceApplication,
        //            annotation);
        //    }
        //    if (GoogleLogin.IsGoogleLogin)
        //    {
        //        GoogleLogin.IsGoogleLogin = false;
        //        return SignIn.SharedInstance.HandleUrl(url, sourceApplication, annotation);
        //    }

        //    return false;
        //}

        public override void OnActivated(UIApplication uiApplication)
        {
            base.OnActivated(uiApplication);
            Facebook.CoreKit.AppEvents.ActivateApp();
        }
    }
}
