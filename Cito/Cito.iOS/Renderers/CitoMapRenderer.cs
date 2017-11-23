using System.Collections.Generic;
using System.ComponentModel;
using Cito.Framework.Components;
using Cito.iOS.Renderers;
using CoreGraphics;
using CoreLocation;
using MapKit;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CitoMap), typeof(CitoMapRenderer))]
namespace Cito.iOS.Renderers
{
    internal class CitoMapRenderer : MapRenderer
    {
        internal CitoMap FormsMap;
        internal MKMapView NativeMap;
        internal IList<Pin> Pins;

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                var nativeMap = (MKMapView)Control;
                nativeMap.GetViewForAnnotation = null;
                nativeMap.CalloutAccessoryControlTapped -= OnCalloutAccessoryControlTapped;
                nativeMap.DidSelectAnnotationView -= OnDidSelectAnnotationView;
                nativeMap.DidDeselectAnnotationView -= OnDidDeselectAnnotationView;
            }

            if (e.NewElement != null)
            {
                FormsMap = (CitoMap)e.NewElement;
                NativeMap = (MKMapView)Control;

                NativeMap.GetViewForAnnotation = GetViewForAnnotation;
                NativeMap.CalloutAccessoryControlTapped += OnCalloutAccessoryControlTapped;
                NativeMap.DidSelectAnnotationView += OnDidSelectAnnotationView;
                NativeMap.DidDeselectAnnotationView += OnDidDeselectAnnotationView;
                UpdatePins();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "Pins")
            {
                UpdatePins();
            }
        }

        private void UpdatePins()
        {
            Pins = FormsMap.Pins;
            NativeMap.RemoveAnnotations(NativeMap.Annotations);
            int i = 0;
            foreach (var pin in Pins)
            {
                var ca = new CustomAnnotation(pin, (++i).ToString());
                NativeMap.AddAnnotation(ca);
            }
        }

        MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
        {
            MKAnnotationView annotationView = null;

            if (annotation.GetType() != typeof(CustomAnnotation))
                return null;
            var anno = (CustomAnnotation)annotation;
            var pin = anno.Pin;

            annotationView = mapView.DequeueReusableAnnotation(anno.Id);
            if (annotationView == null)
            {
                annotationView = new CustomMKAnnotationView(anno.Id, anno.Title, pin.Position)
                {
                    CalloutOffset = new CGPoint(0, 0),
                    RightCalloutAccessoryView = UIButton.FromType(UIButtonType.DetailDisclosure)
                };

                annotationView.LeftCalloutAccessoryView = new UIImageView(UIImage.FromFile("CitoPin.png"));
                annotationView.Image = UIImage.FromFile("CitoPin.png");
              
            }
            annotationView.CanShowCallout = true;

            return annotationView;
        }

        void OnDidSelectAnnotationView(object sender, MKAnnotationViewEventArgs e)
        {
            //var customView = e.View as CustomMKAnnotationView;
            //if (customView == null) return;

            //_customPinView = new UIView();

            //if (customView.Id != "Xamarin") return;
            //_customPinView.Frame = new CGRect(0, 0, 200, 84);
            //var image = new UIImageView(new CGRect(0, 0, 200, 84));
            //image.Image = UIImage.FromFile("xamarin.png");
            //_customPinView.AddSubview(image);
            //_customPinView.Center = new CGPoint(0, -(e.View.Frame.Height + 75));
            //e.View.AddSubview(_customPinView);
        }

        void OnCalloutAccessoryControlTapped(object sender, MKMapViewAccessoryTappedEventArgs e)
        {
          
        }


        void OnDidDeselectAnnotationView(object sender, MKAnnotationViewEventArgs e)
        {
            if (!e.View.Selected)
            {
                //_customPinView.RemoveFromSuperview();
                //_customPinView.Dispose();
                //_customPinView = null;
            }
        }
    }

    public class CustomAnnotation : MKAnnotation
    {
        public CustomAnnotation(Pin pin, string id)
        {

            Pin = pin;
            Id = "Pin " + id;
            Coordinate = new CLLocationCoordinate2D(pin.Position.Latitude, pin.Position.Longitude);
        }

        public Pin Pin { get; }
        public string Id { get; }
        public override string Title => Pin?.Label;
        public override CLLocationCoordinate2D Coordinate { get; }
    }

    public class CustomMKAnnotationView : MKAnnotationView
    {
        public CustomMKAnnotationView(string id, string title, Position position)
        {
            Id = id;
            Title = title;
            Position = position;
        }

        public string Id { get; }
        public string Title { get; }
        public Position Position { get; }
    }
}
