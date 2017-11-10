using System;
using Acr.UserDialogs;
using Android.App;
using Android.Appwidget;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using ImageCircle.Forms.Plugin.Droid;
using Xamarin.Facebook;
using Xamarin.Forms;
using Context = System.Runtime.Remoting.Contexts.Context;


namespace Cito.Droid
{
    [Activity(Label = "Cito", Name = "cito.MainActivity", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {        
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            System.Net.ServicePointManager.DnsRefreshTimeout = 0;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            Xamarin.FormsMaps.Init(this, bundle);
            ImageCircleRenderer.Init();
            UserDialogs.Init(this);

            if (FacebookSdk.IsInitialized)
                FacebookLogin.Handle();
            
            

            LoadApplication(new App());

        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            FacebookLogin.CallbackManager.OnActivityResult(requestCode, (int)resultCode, data);
        }      

    }

 
}

