using System.Windows.Input;
using Xamarin.Forms;

namespace Cito.Framework.Components
{
    public partial class MenuItem : ContentView
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
            typeof(MenuItem),
            null,
            BindingMode.TwoWay);
        #endregion
        #region ImageProperty
        public static BindableProperty ImageProperty = BindableProperty.Create(
            "Image",
            typeof(string),
            typeof(MenuItem),
            "",
            BindingMode.TwoWay,
            propertyChanged: SetImage);

        private static void SetImage(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (newvalue != null)
                ((MenuItem)bindable).ItemImage.Source = new FileImageSource() { File = (string)newvalue };
        }

        private string _menuItemImage;

        public string MenuItemImage
        {
            get { return _menuItemImage; }
            set
            {
                _menuItemImage = value;
                SetValue(ImageProperty, value);
            }
        }
        #endregion
        #region TextProperty
        public static BindableProperty TextProperty = BindableProperty.Create(
            "Text",
            typeof(string),
            typeof(MenuItem),
            "",
            BindingMode.TwoWay,
            propertyChanged: SetText);

        private static void SetText(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (newvalue != null)
                ((MenuItem)bindable).ItemText.Text = (string)newvalue;
        }

        private string _menuItemText;

        public string MenuItemText
        {
            get { return _menuItemText; }
            set
            {
                _menuItemText = value;
                SetValue(TextProperty, value);
            }
        }

        #endregion
        #region ColorBackgroundProperty
        public static BindableProperty ColorBackgroundProperty = BindableProperty.Create(
            "Color",
            typeof(Color),
            typeof(MenuItem),
            Color.FromHex("FFECEAE7"),
            BindingMode.TwoWay,
            propertyChanged: SetColor);

        private static void SetColor(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (newvalue != null)
                ((MenuItem)bindable).MainStack.BackgroundColor = (Color)newvalue;
        }

        private Color _menuItemColor;

        public Color MenuItemColor
        {
            get { return _menuItemColor; }
            set
            {
                _menuItemColor = value;
                SetValue(ColorBackgroundProperty, value);
            }
        }

        #endregion
        //#region IsSelectedProperty
        //public static BindableProperty IsSelectedProperty = BindableProperty.Create(
        //    "IsSelected",
        //    typeof(bool),
        //    typeof(MenuItem),
        //    false,
        //    BindingMode.TwoWay,
        //    propertyChanged: ItemSelected);

        //private static void ItemSelected(BindableObject bindable, object oldvalue, object newvalue)
        //{
        //    if ((bool)newvalue)
        //    {
        //        ((MenuItem)bindable).MainStack.BackgroundColor =
        //            (Color)Application.Current.Resources["CitoMainLight"];
        //        ((MenuItem)bindable).ItemText.TextColor = (Color)Application.Current.Resources["CitoLight"];
        //        if (((MenuItem)bindable).ItemImage != null)
        //        {
        //            var currentImage = ((FileImageSource)(((MenuItem)bindable).ItemImage.Source)).File;
        //            var name = currentImage.Remove(currentImage.IndexOf("."));
        //            ((MenuItem)bindable).ItemImage.Source = new FileImageSource()
        //            {
        //                File = (string)name + "_selected.png"
        //            };
        //        }
        //        ((MenuItem)bindable).IsSelected = true;
        //        ((MenuItem)bindable).BorderTop.Opacity = 0.3;
        //        ((MenuItem)bindable).BorderBottom.Opacity = 0.3;
        //    }
        //    else
        //    {
        //        ((MenuItem)bindable).MainStack.BackgroundColor =
        //          (Color)Application.Current.Resources["CitoMain"];
        //        ((MenuItem)bindable).ItemText.TextColor = (Color)Application.Current.Resources["CitoLight"];
        //        if (((MenuItem)bindable).ItemImage != null)
        //        {
        //            var currentImage = ((FileImageSource)(((MenuItem)bindable).ItemImage.Source)).File;
        //            var name = currentImage.Remove(currentImage.IndexOf("."));
        //            ((MenuItem)bindable).ItemImage.Source = new FileImageSource()
        //            {
        //                File = name.Replace("_selected", "") + ".png"
        //            };
        //        }
        //        ((MenuItem)bindable).IsSelected = false;
        //        ((MenuItem)bindable).BorderTop.Opacity = 0;
        //        ((MenuItem)bindable).BorderBottom.Opacity = 0;
        //    }
        //}

        //private bool _isSelected;

        //public bool IsSelected
        //{
        //    get { return _isSelected; }
        //    set
        //    {
        //        _isSelected = value;
        //        SetValue(IsSelectedProperty, value);
        //    }
        //}

        //#endregion
        #region BorderTopVisibility

        public bool BorderTopVisibility
        {
            get { return BorderTop.IsVisible; }
            set { BorderTop.IsVisible = value; }
        }
        #endregion
        #region BorderBottomVisibility

        public bool BorderBottomVisibility
        {
            get { return BorderBottom.IsVisible; }
            set { BorderBottom.IsVisible = value; }
        }
        #endregion

        #endregion
        public MenuItem()
        {
            InitializeComponent();
            AddGestures();
        }

        #region Methods

        private void AddGestures()
        {
            var gestureRecognizer = new TapGestureRecognizer();

            gestureRecognizer.Tapped += (s, e) => {
                if (Command != null && Command.CanExecute(null))
                {
                    Command.Execute(null);
                }
            };

            MainStack.GestureRecognizers.Add(gestureRecognizer);
        }

        #endregion


    }
}
