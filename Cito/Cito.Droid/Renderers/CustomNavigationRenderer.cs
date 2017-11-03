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
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;
using View = Android.Views.View;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(CustomNavigationRenderer))]
namespace Cito.Droid.Renderers
{
    internal class CustomNavigationRenderer : NavigationPageRenderer
    {
        protected override void SetupPageTransition(Android.Support.V4.App.FragmentTransaction transaction, bool isPush)
        {
            if (isPush)
                transaction.SetCustomAnimations(Resource.Animation.abc_fade_in,
                    Resource.Animation.abc_fade_in,
                    Resource.Animation.abc_fade_in,
                    Resource.Animation.abc_slide_in_bottom);
            else
                transaction.SetCustomAnimations(Resource.Animation.abc_fade_in,
                    Resource.Animation.abc_fade_in,
                    Resource.Animation.abc_fade_in,
                    Resource.Animation.abc_fade_in);
     
        }

        //protected override void OnLayout(bool changed, int l, int t, int r, int b)
        //{
        //    base.OnLayout(changed, l, t, r, b);

        //    var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
        //    for (var i = 0; i < toolbar.ChildCount; i++)
        //    {
        //        var imageButton = toolbar.GetChildAt(i) as ImageButton;

        //        var drawerArrow = imageButton?.Drawable as DrawerArrowDrawable;
        //        if (drawerArrow == null)
        //            continue;
        //        if (App.MainPageNames.Any(x => x.Equals(toolbar.Title, StringComparison.OrdinalIgnoreCase)))
        //            imageButton.SetImageDrawable(ContextCompat.GetDrawable(Context, Resource.Drawable.menu));
        //        else
        //            imageButton.Drawable.Alpha = 80;
        //    }
        //}
    }
}