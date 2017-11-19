using Cito.Droid.Renderers;
using Cito.Framework.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CitoLabel), typeof(CitoLabelRenderer))]
namespace Cito.Droid.Renderers
{
    internal class CitoLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            Control.Typeface = e.NewElement?.FontAttributes == FontAttributes.Bold
                ? Typefaces.FontBold
                : Typefaces.FontRegular;
        }
    }
}