using System;
using System.Collections.Generic;
using System.Text;
using Cito.Framework.Controls;
using Cito.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CitoEditor), typeof(CitoEditorRenderer))]
namespace Cito.iOS.Renderers
{
    internal class CitoEditorRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (Control == null) return;

            Control.Layer.BorderWidth = 1;
            Control.Layer.BorderColor = UIColor.FromRGBA(168, 168, 168, 255).CGColor;
            Control.Layer.CornerRadius = 0;
            Control.ClipsToBounds = true;
            Control.BackgroundColor = UIColor.Clear;
            Control.TintColor = UIColor.FromRGBA(108, 197, 235, 255);
        }
    }
}


