using Cito.Droid.Renderers;
using Cito.Framework.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CitoButton), typeof(CitoButtonRenderer))]
namespace Cito.Droid.Renderers
{
    internal class CitoButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.SetAllCaps(false);
                Control.SetShadowLayer(0, 0, 0, Android.Graphics.Color.Transparent);
                Control.Typeface = e.NewElement?.FontAttributes == FontAttributes.Bold
                    ? Typefaces.FontBold
                    : Typefaces.FontRegular;
            }
        }
    }
}