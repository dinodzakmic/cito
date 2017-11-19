using Cito.Framework.Controls;
using Cito.iOS.Renderers;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CitoEntry), typeof(CitoEntryRenderer))]
namespace Cito.iOS.Renderers
{
    internal class CitoEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            Control.LeftView = new UIView(new CGRect(0, 0, 15, Control.Frame.Height));
            Control.LeftViewMode = UITextFieldViewMode.Always;

            Control.BorderStyle = UITextBorderStyle.None;
            Control.Layer.CornerRadius = 0;
            Control.ClipsToBounds = true;
            Control.BackgroundColor = UIColor.Clear;

            if (e.NewElement != null && ((CitoEntry)e.NewElement).IsFirstLetterUpperCase)
            {
                Control.AutocapitalizationType = UITextAutocapitalizationType.Sentences;
                Control.AutocorrectionType = UITextAutocorrectionType.No;
            }

            if (e.NewElement != null && !((CitoEntry)e.NewElement).IsAutoCorrectEnabled)
            {
                Control.AutocorrectionType = UITextAutocorrectionType.No;
                if (!((CitoEntry)e.NewElement).IsFirstLetterUpperCase)
                    Control.AutocapitalizationType = UITextAutocapitalizationType.None;
            }
        }
    }
}
