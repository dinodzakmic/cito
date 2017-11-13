using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Cito.Framework.Components
{
    public partial class CitoMap : Map
    {
        #region Private properties

        #endregion
        #region Public properties
        #region PinImage

        #endregion
        #region BindablePins
        public static readonly BindableProperty BindablePinsProperty = BindableProperty
            .Create(
                propertyName: nameof(BindablePins),
                returnType: typeof(List<Pin>),
                declaringType: typeof(CitoMap),
                defaultValue: new List<Pin>(),
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: (b, o, n) =>
                {
                    
                    var map = ((CitoMap)b);
                    map.PinsChanged?.Invoke();

                });
        public List<Pin> BindablePins
        {
            get
            {
                return (List<Pin>)GetValue(BindablePinsProperty);
            }
            set
            {
                SetValue(BindablePinsProperty, value);
            }
        }

        public Action PinsChanged = () => { };
        #endregion
        #region CurrentPosition
        public static readonly BindableProperty CurrentPositionProperty = BindableProperty
            .Create(
                propertyName: nameof(CurrentPosition),
                returnType: typeof(Position),
                declaringType: typeof(CitoMap),
                defaultValue: new Position(0, 0),
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: (b, o, n) =>
                {
                    var map = (CitoMap)b;
                    var position = (Position)n;
                    var distance = map.CurrentDistance;

                    map.MoveToRegion(MapSpan.FromCenterAndRadius(position, distance));
                });

        public Position CurrentPosition
        {
            get { return (Position) GetValue(CurrentPositionProperty); }
            set { SetValue(CurrentPositionProperty, value); }
        }


        public Distance CurrentDistance { get; set; } = Distance.FromKilometers(1);
        #endregion
        #region MapPin

        public string MapPin { get; set; }
        #endregion
        #endregion
        public CitoMap()
        {
            InitializeComponent();
        }

        #region Methods


        #endregion
    }
}
