using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Cito.Framework.Controls;
using Xamarin.Forms;

namespace Cito.Framework.Components
{
    public partial class ImageButton : ContentView
    {
        #region Private properties

        #endregion
        #region Public properties

        #region Command

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public static BindableProperty CommandProperty = BindableProperty.Create(
            "Command",
            typeof(ICommand),
            typeof(ImageButton),
            null,
            BindingMode.TwoWay);
        

        #endregion
        #region Button

        public CitoButton CitoButton
        {
            get { return Button; }
            set { Button = value; }
        }

        #endregion
        #region ButtonText

        public static BindableProperty ButtonTextProperty = BindableProperty.Create(
            propertyName: nameof(ButtonText),
            returnType: typeof(string),
            declaringType: typeof(ImageButton),
            defaultBindingMode: BindingMode.TwoWay,
            defaultValue: string.Empty,
            propertyChanged: (b, o, n) => { ((ImageButton)b).LabelText.Text = (string)n; });
        public string ButtonText
        {
            get { return (string)GetValue(ButtonTextProperty); }
            set { SetValue(ButtonTextProperty, value); }
        }

        public double ButtonTextSize
        {
            get { return LabelText.FontSize; }
            set { LabelText.FontSize = value; }
        }

        public TextAlignment ButtonTextHorizontalTextAlignment
        {
            get { return LabelText.HorizontalTextAlignment; }
            set
            {
                if (value == TextAlignment.Center)
                {
                    LabelText.TranslationX = 70;
                }
            }
        }
        public TextAlignment ButtonTextVerticalTextAlignment
        {
            get { return LabelText.VerticalTextAlignment; }
            set { LabelText.VerticalTextAlignment = value; }
        }

        #endregion
        #region ButtonImage

        public static BindableProperty ButtonImageProperty = BindableProperty.Create(
            propertyName: nameof(ButtonImage),
            returnType: typeof(ImageSource),
            declaringType: typeof(ImageButton),
            defaultBindingMode: BindingMode.TwoWay,
            defaultValue: null,
            propertyChanged: (b, o, n) => { ((ImageButton)b).Image.Source = (ImageSource)n; });

        public ImageSource ButtonImage
        {
            get { return (string)GetValue(ButtonImageProperty); }
            set { SetValue(ButtonImageProperty, value); }
        }

        #endregion
        #region ImageHeight
        public double ImageHeight
        {
            get { return Image.HeightRequest; }
            set { Image.HeightRequest = value; }
        }
        #endregion
        #region Clicked events

        public event EventHandler Clicked
        {
            add { Button.Clicked += value; }
            remove { Button.Clicked -= value; }
        }

        #endregion
        #region Social

        public Social ExternalLogin { get; set; }

        public enum Social
        {
            Facebook = 1,
            Google = 2
        }

        #endregion

        #endregion

        public ImageButton()
        {
            InitializeComponent();
        }

    }
}
