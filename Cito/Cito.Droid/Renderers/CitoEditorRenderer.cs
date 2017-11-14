using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using Cito.Droid.Renderers;
using Cito.Framework.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CitoEditor), typeof(CitoEditorRenderer))]
namespace Cito.Droid.Renderers
{
    internal class CitoEditorRenderer : EditorRenderer
    {
        internal Editor CitoEditor;
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (Control == null) return;

            Control.Typeface = e.NewElement?.FontAttributes == FontAttributes.Bold
                ? Typefaces.FontBold
                : Typefaces.FontRegular;


            Control.Measure(0, 0);
            var height = Control.MeasuredHeight;
            var width = Control.MeasuredWidth;
            Control.Background = new FixedDrawable(height, width);


            if (e.NewElement != null)
            {
                CitoEditor = e.NewElement;
            }
        }
    }

    sealed class FixedDrawable : GradientDrawable
    {
        public FixedDrawable(int height, int width)
        {
            SetShape(ShapeType.Rectangle);
            IntrinsicHeight = height;
            SetColors(new int[] { Android.Graphics.Color.Transparent, Android.Graphics.Color.Transparent });
            SetStroke(2, new Android.Graphics.Color() { A = 255, R = 109, G = 197, B = 237 });
            SetCornerRadius(0);
            SetBounds(0, 0, width, height);

        }

        public override int IntrinsicHeight { get; }
    }
}