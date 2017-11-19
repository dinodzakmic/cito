using Android.Graphics;
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