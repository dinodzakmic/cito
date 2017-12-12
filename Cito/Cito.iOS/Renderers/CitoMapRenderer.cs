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
        internal UIView CustomPinView;

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
                FormsMap.PinsChanged += UpdatePins;
                NativeMap.ZoomEnabled = true;

                NativeMap.GetViewForAnnotation = GetViewForAnnotation;
                NativeMap.CalloutAccessoryControlTapped += OnCalloutAccessoryControlTapped;
                NativeMap.DidSelectAnnotationView += OnDidSelectAnnotationView;
                NativeMap.DidDeselectAnnotationView += OnDidDeselectAnnotationView;
                UpdatePins();
            }
        }


        private void UpdatePins()
        {
            Pins = FormsMap.BindablePins;
            NativeMap.RemoveAnnotations(NativeMap.Annotations);

            int i = 0;
            foreach (var pin in Pins)
            {
                var ca = new CustomAnnotation(pin, (++i).ToString(), pin.Type);
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
                annotationView = new CustomMKAnnotationView(anno.Id, anno.Title, anno.Subtitle, pin.Position, anno.Type)
                {
                    CalloutOffset = new CGPoint(10, 10),
                    RightCalloutAccessoryView = UIButton.FromType(UIButtonType.DetailDisclosure)
                };

                if (pin.Type == PinType.Generic)
                {
                    annotationView.LeftCalloutAccessoryView = new UIImageView(UIImage.FromFile("UserLocation.png"));
                    annotationView.Image = UIImage.FromFile("UserLocation.png");
                }
                else
                {
                    annotationView.LeftCalloutAccessoryView = new UIImageView(UIImage.FromFile("CitoPin.png"));
                    annotationView.Image = UIImage.FromFile("CitoPin.png");
                }
            }
            annotationView.CanShowCallout = false;
            

            return annotationView;
        }

        void OnDidSelectAnnotationView(object sender, MKAnnotationViewEventArgs e)
        {
            var customView = e.View as CustomMKAnnotationView;
            if (customView == null) return;

            FormsMap.MoveToRegion(MapSpan.FromCenterAndRadius(customView.Position, Distance.FromKilometers(1)));

            if (customView.Type == PinType.Generic) return;

            CustomPinView = new UIView();

            CustomPinView.Frame = new CGRect(0, 0, 300, 65);
            CustomPinView.BackgroundColor = UIColor.FromRGB(38, 162, 171); 

            //var image = new UIImageView(new CGRect(0, 0, 200, 84));
            //image.Image = UIImage.FromFile("map_pin_atm.png");
            var btn = new UIImageView()
            {
                Frame = new CGRect(240, 5, 60, 60),
                Image = UIImage.FromFile("OwnerProfileImage.png")
            };
     
            var title = new UILabel
            {
                Frame = new CGRect(5, 5, 235, 35),
                Text = customView.Title,
                TextColor = UIColor.White
            };
            var subtitle = new UILabel
            {
                Frame = new CGRect(5, 35, 235, 20),
                Text = customView.Subtitle,
                TextColor = UIColor.White
            };

            CustomPinView.AddSubviews(btn, title, subtitle);
            CustomPinView.Center = new CGPoint(0, -(e.View.Frame.Height) + 20);
            e.View.AddSubview(CustomPinView);
        }

        void OnCalloutAccessoryControlTapped(object sender, MKMapViewAccessoryTappedEventArgs e)
        {
            var customView = (CustomMKAnnotationView)e.View;
            App.Locator.Map.GoToCardDetailsCommand.Execute(null);
        }

        void ExecuteCommand()
        {
            App.Locator.Map.GoToCardDetailsCommand.Execute(null);
        }
        void OnDidDeselectAnnotationView(object sender, MKAnnotationViewEventArgs e)
        {
            
            if (!e.View.Selected)
            {
                if (CustomPinView == null) return;     
                CustomPinView.RemoveFromSuperview();
                CustomPinView.Dispose();
                ExecuteCommand();
                CustomPinView = null;               
            }
        }
    }

    public class CustomAnnotation : MKAnnotation
    {
        public CustomAnnotation(Pin pin, string id, PinType type)
        {
            Pin = pin;
            Id = "Pin " + id;
            Type = type;
            Coordinate = new CLLocationCoordinate2D(pin.Position.Latitude, pin.Position.Longitude);
        }

        public PinType Type { get; set; }
        public Pin Pin { get; }
        public string Id { get; }
        public override string Title => Pin?.Label;
        public override string Subtitle => Pin?.Address;
        public override CLLocationCoordinate2D Coordinate { get; }
    }

    public class CustomMKAnnotationView : MKAnnotationView
    {
        public CustomMKAnnotationView(string id, string title, string subtitle, Position position, PinType type)
        {
            Id = id;
            Title = title;
            Subtitle = subtitle;
            Position = position;
            Type = type;
        }

        public string Id { get; }
        public string Title { get; }
        public string Subtitle { get; }
        public Position Position { get; }
        public PinType Type { get; }
    }
}
