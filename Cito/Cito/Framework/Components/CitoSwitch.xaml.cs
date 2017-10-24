using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Cito.Framework.Components
{
    public partial class CitoSwitch : ContentView
    {
        internal List<double> XPoints = new List<double>();
        internal bool IsInitialized { get; set; } = false;

        public static readonly BindableProperty IsToggledProperty = BindableProperty
                    .Create(
            propertyName: nameof(IsToggled),
            returnType: typeof(bool),
            declaringType: typeof(CitoSwitch),
            defaultValue: false,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: async (b, o, n) => 
            {
                var isToggled = ((CitoSwitch)b).IsToggled;
                var box = ((CitoSwitch) b).Box;
                var isInitialized = ((CitoSwitch) b).IsInitialized;

                if (!isInitialized)
                {
                    if (isToggled)
                    {
                        box.TranslationX = 60;
                    }
                    else
                    {
                        box.TranslationX = 0;
                    }

                    ((CitoSwitch) b).IsInitialized = true;
                }
                else
                {
                    var xCoordinate = box.TranslationX;

                    if (isToggled)
                    {
                        await box.LayoutTo(new Rectangle(60 - xCoordinate, box.Y, box.Width, box.Height), 150U, Easing.SinOut);
                    }
                    else
                    {
                        await box.LayoutTo(new Rectangle(0 - xCoordinate, box.Y, box.Width, box.Height), 150U, Easing.SinIn);
                    }

                    
                }          
            });
        public bool IsToggled
        {
            get
            {
                return (bool)GetValue(IsToggledProperty);
            }
            set
            {
                SetValue(IsToggledProperty, value);
            }
        }

      

        public CitoSwitch()
        {
            InitializeComponent();           
        }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            IsInitialized = true;
            IsToggled = !IsToggled;
        }

        private void PanGestureRecognizer_OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            IsInitialized = true;
            if (e.StatusType == GestureStatus.Running || e.StatusType == GestureStatus.Started)
            {
                XPoints.Add(e.TotalX);
                return;
            }

            if (!IsToggled && XPoints.Max() > 10)
            {
                XPoints.Clear();
                IsToggled = !IsToggled;
            }
            else if (IsToggled && XPoints.Min() < -10)
            {
                XPoints.Clear();
                IsToggled = !IsToggled;             
            }


        }

    }
}
