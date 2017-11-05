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

        public CitoButton CitoButton
        {
            get { return Button; }
            set { Button = value; }
        }
        public string ButtonText
        {
            get { return LabelText.Text; }
            set { LabelText.Text = value; }
        }

        public ImageSource ButtonImage
        {
            get { return Image.Source; }
            set { Image.Source = value; }
        }



        public event EventHandler Clicked
        {
            add { Button.Clicked += value; }
            remove { Button.Clicked -= value; }
        }

        public Social ExternalLogin { get; set; }

        public enum Social
        {
            Facebook = 1,
            Google = 2
        }

        #endregion

        public ImageButton()
        {
            InitializeComponent();
        }

        #region MyRegion

        #endregion
    }
}
