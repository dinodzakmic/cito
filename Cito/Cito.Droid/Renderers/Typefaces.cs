using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

namespace Cito.Droid.Renderers
{
    public static class Typefaces
    {
        public static Typeface FontRegular { get; } = Typeface.CreateFromAsset(Forms.Context.Assets, "Lato-Regular.ttf");
        public static Typeface FontBold { get; } = Typeface.CreateFromAsset(Forms.Context.Assets, "Lato-Bold.ttf");
        public static Typeface FontAwesome { get; } = Typeface.CreateFromAsset(Forms.Context.Assets, "fontawesome-webfont.ttf");
    }
}