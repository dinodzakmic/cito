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

                    map.Pins.Clear();

                    var pins = ((List<Pin>)n);

                    map.InitializeComponent();

                    foreach (var pin in pins)
                    {
                        map.Pins.Add(pin);
                    }
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
