using System.Diagnostics;
using Cito.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIBarStyle = UIKit.UIBarStyle;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(CitoNavigationPageRenderer))]
namespace Cito.iOS.Renderers
{
    internal class CitoNavigationPageRenderer : NavigationRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            //if (e.NewElement != null)
            //{
            //    var uiTapGestureRecognizer = new UITapGestureRecognizer(a => View.EndEditing(true));

            //    uiTapGestureRecognizer.ShouldRecognizeSimultaneously = (recognizer, gestureRecognizer) => true;
            //    uiTapGestureRecognizer.ShouldReceiveTouch = OnShouldReceiveTouch;
            //    uiTapGestureRecognizer.DelaysTouchesBegan =
            //        uiTapGestureRecognizer.DelaysTouchesEnded = uiTapGestureRecognizer.CancelsTouchesInView = false;
            //    View.AddGestureRecognizer(uiTapGestureRecognizer);
            //}

            NavigationBar.BarStyle = UIBarStyle.BlackTranslucent;
        }
    }
}
