using Android.Graphics;
using Android.Support.V7.Graphics.Drawable;
using Android.Util;
using Android.Widget;
using Cito.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;
using Color = Android.Graphics.Color;
using Toolbar = Android.Support.V7.Widget.Toolbar;

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


        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            if (toolbar == null) return;
            
            toolbar.SetBackgroundResource(Resource.Drawable.NavigationBarGradient);
            
            //toolbar.SetNavigationIcon(Resource.Drawable.MenuIcon);

            for (var i = 0; i < toolbar.ChildCount; i++)
            {
                var currentChild = toolbar.GetChildAt(i);

                var titleText = currentChild as TextView;
                titleText?.SetTypeface(Typefaces.FontRegular, TypefaceStyle.Normal);
                titleText?.SetElegantTextHeight(true);
                titleText?.SetTextSize(ComplexUnitType.Dip, 15);
                titleText?.SetX(150);

                var imageButton = currentChild as ImageButton;
                var drawerArrow = imageButton?.Drawable as DrawerArrowDrawable;

                if (drawerArrow != null)
                {
                    imageButton.SetColorFilter(Color.Rgb(103, 200, 207));
                }
                else
                {
                    imageButton?.SetImageResource(Resource.Drawable.MenuIcon);
                }               
            }
        }
    }
}