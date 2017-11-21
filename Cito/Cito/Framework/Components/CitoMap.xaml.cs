using System;
using System.Collections.Generic;
using Cito.Framework.Utilities;
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

                    map.BindablePins.RemoveAll(p => p.Type == PinType.Generic);
                    map.BindablePins.Add(new Pin()
                    {
                        Address = "Owner",
                        Label = "Owner",
                        Position = position,
                        Type = PinType.Generic
                    });
                    map.PinsChanged?.Invoke();
                });

        public Position CurrentPosition
        {
            get { return (Position) GetValue(CurrentPositionProperty); }
            set { SetValue(CurrentPositionProperty, value); }
        }


        public Distance CurrentDistance { get; set; } = Distance.FromKilometers(2);
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
