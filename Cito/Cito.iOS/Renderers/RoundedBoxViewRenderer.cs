using System;
using System.Collections.Generic;
using System.Text;
using Cito.Framework.Components;
using Cito.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(RoundedBoxView), typeof(RoundedBoxViewRenderer))]
namespace Cito.iOS.Renderers
{
    internal class RoundedBoxViewRenderer : BoxRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);

            if (Element == null)
                return;

            Layer.MasksToBounds = true;
            Layer.CornerRadius = (float)((RoundedBoxView)Element).CornerRadius / 2.0f;
        }
    }
}
