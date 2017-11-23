using Cito.Framework.Controls;
using Cito.iOS.Renderers;
using CoreGraphics;
using Foundation;
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

            //Control.LeftView = new UIView(new CGRect(0, 0, 15, Control.Frame.Height));
            //Control.LeftViewMode = UITextFieldViewMode.Always;


            Control.BorderStyle = UITextBorderStyle.Line;
            Control.Layer.BorderWidth = 1;
            Control.Layer.BorderColor = UIColor.FromRGBA(168, 168, 168, 255).CGColor;
            Control.Layer.CornerRadius = 0;
            Control.TextAlignment = UITextAlignment.Center;
            Control.ClipsToBounds = true;
            Control.BackgroundColor = UIColor.Clear;
            Control.TintColor = UIColor.FromRGBA(108, 197, 235, 255);

            var newElement = (CitoEntry)e.NewElement;

            if (newElement != null)
                Control.Enabled = newElement.HasFocusable;

            if (newElement != null && newElement.IsFirstLetterUpperCase)
            {
                Control.AutocapitalizationType = UITextAutocapitalizationType.Sentences;
                Control.AutocorrectionType = UITextAutocorrectionType.No;
            }

            if (newElement != null && !newElement.IsAutoCorrectEnabled)
            {
                Control.AutocorrectionType = UITextAutocorrectionType.No;
                if (!newElement.IsFirstLetterUpperCase)
                    Control.AutocapitalizationType = UITextAutocapitalizationType.None;
            }
        }
    }
}
