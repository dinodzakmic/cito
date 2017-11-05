using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cito.Droid.Renderers;
using Cito.Framework.Components;
using Java.Interop;
using Xamarin.Forms;
using Xamarin.Forms.Maps.Android;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V7.Widget;
using Java.Net;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;

[assembly: ExportRenderer(typeof(CitoMap), typeof(CitoMapRenderer))]
namespace Cito.Droid.Renderers
{
    internal class CitoMapRenderer : MapRenderer, GoogleMap.IInfoWindowAdapter, IOnMapReadyCallback
    {
        internal GoogleMap GoogleMap;
        internal CitoMap FormsMap;
        internal bool IsDrawnDone;
        internal IList<Pin> Pins;

        public void OnMapReady(GoogleMap googleMap)
        {
            GoogleMap = googleMap;
            //MapGoogle.InfoWindowClick += OnInfoWindowClick;
            GoogleMap.SetInfoWindowAdapter(this);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
            {
                //MapGoogle.InfoWindowClick -= OnInfoWindowClick;
            }

            if (e.NewElement != null)
            {
                FormsMap = (CitoMap)e.NewElement;
                Pins = FormsMap.Pins;
                ((MapView)Control).GetMapAsync(this);
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (!IsDrawnDone && GoogleMap != null)
            {
                GoogleMap.Clear();

                foreach (var pin in Pins)
                {
                    var marker = new MarkerOptions();
                    marker.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
                    marker.SetTitle(pin.Label);
                    marker.SetSnippet(pin.Address);
                    marker.SetIcon(GetPinIcon());
                    GoogleMap.AddMarker(marker);
                }

                IsDrawnDone = true;
            }
        }

        private BitmapDescriptor GetPinIcon()
        {
            var drawableResource = Context.Resources.GetDrawable(FormsMap.MapPin);
            return BitmapDescriptorFactory.FromBitmap(((BitmapDrawable)drawableResource).Bitmap);
        }

        public View GetInfoWindow(Marker marker)
        {
            LayoutInflater inflater =
                Android.App.Application.Context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;

            if (inflater != null)
            {
                View view = inflater.Inflate(Resource.Layout.MapInfo, null);
                var infoTitle = view.FindViewById(Resource.Id.infoWindowTitle) as TextView;
                var infoSubtitle = view.FindViewById(Resource.Id.infoWindowSubtitle) as TextView;
                var icon = view.FindViewById(Resource.Id.infoWindowImage) as ImageView;
                if (icon != null)
                {
                    //icon.Text = (Pins.First(x => x.Position == new Position(marker.Position.Latitude, marker.Position.Longitude)).Type == PinType.Place) ? "4" : "J";
                    //icon.SetTypeface(Typefaces.FontIcon, TypefaceStyle.Normal);
                }

                if (infoTitle != null)
                {
                    infoTitle.Text = marker.Title;
                    //infoTitle.SetTypeface(Typefaces.FontM, TypefaceStyle.Normal);
                }
                if (infoSubtitle != null)
                {
                    infoSubtitle.Text = marker.Snippet;
                    //infoSubtitle.SetTypeface(Typefaces.FontL, TypefaceStyle.Normal);
                }

                return view;
            }
            return null;
        }

        public View GetInfoContents(Marker marker)
        {
            return null;
        }

    }
}