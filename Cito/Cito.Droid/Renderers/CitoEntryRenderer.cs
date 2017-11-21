using Android.Graphics.Drawables;
using Android.Text;
using Android.Views;
using Cito.Droid.Renderers;
using Cito.Framework.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CitoEntry), typeof(CitoEntryRenderer))]

namespace Cito.Droid.Renderers
{
    internal class CitoEntryRenderer : EntryRenderer
    {
        public double KeyboardHeight { get; set; }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control == null) return;

            //Control.Background = ContextCompat.GetDrawable(Control.Context, Resource.Drawable.RoundedEntry);

            Control.Typeface = e.NewElement?.FontAttributes == FontAttributes.Bold
                ? Typefaces.FontBold
                : Typefaces.FontRegular;

            Control.Measure(0, 0);
            var height = Control.MeasuredHeight;
            var width = Control.MeasuredWidth;
            var textsize = Control.LineHeight + Control.LineSpacingExtra;
            const int roundedsize = 4;
            var padding = (height - (int) textsize - roundedsize) / 2;
            Control.SetPadding(Control.PaddingLeft + 20, padding, Control.PaddingRight, padding);
            Control.Background = new FixedDrawable(height, width);
            Control.Gravity = GravityFlags.CenterVertical | GravityFlags.CenterHorizontal;
            

            var newElement = (CitoEntry) e.NewElement;
            
            if(newElement != null)
                Control.Focusable = newElement.HasFocusable;

            if (newElement != null && newElement.IsFirstLetterUpperCase)
                Control.InputType = InputTypes.ClassText | InputTypes.TextFlagCapSentences |
                                    InputTypes.TextFlagNoSuggestions;

            if (newElement != null && !newElement.IsAutoCorrectEnabled)
                Control.InputType = InputTypes.ClassText | InputTypes.TextFlagNoSuggestions;

            if (newElement?.NextView != null )
            {
                Control.ImeOptions = Android.Views.InputMethods.ImeAction.Next;
                Control.EditorAction += (sender, args) =>
                {
                    newElement.OnNext();
                };
            }

        }



        sealed class FixedDrawable : GradientDrawable
        {
            public FixedDrawable(int height, int width)
            {
                SetShape(ShapeType.Rectangle);
                IntrinsicHeight = height;
                SetColors(new int[] {Android.Graphics.Color.Transparent, Android.Graphics.Color.Transparent});
                SetStroke(2, new Android.Graphics.Color() {A = 255, R = 168, G = 168, B = 168});
                SetCornerRadius(0);
                SetBounds(0, 0, width, height);

            }

            public override int IntrinsicHeight { get; }
        }
    }
}