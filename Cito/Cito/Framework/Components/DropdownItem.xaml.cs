using System;
using Cito.Framework.Controls;
using Xamarin.Forms;

namespace Cito.Framework.Components
{
    public partial class DropdownItem : ContentView
    {
        #region Private properties

        #endregion
        #region Public properties

        #region TopSeparator
        public bool TopSeparatorVisible
        {
            get { return TopSeparator.IsVisible; }
            set { TopSeparator.IsVisible = value; }
        }

        public Color TopSeparatorColor
        {
            get { return TopSeparator.BackgroundColor; }
            set { TopSeparator.BackgroundColor = value; }
        }

        #endregion
        #region BottomSeparator
        public bool BottomSeparatorVisible
        {
            get { return BottomSeparator.IsVisible; }
            set { BottomSeparator.IsVisible = value; }
        }

        public Color BottomSeparatorColor
        {
            get { return BottomSeparator.BackgroundColor; }
            set { BottomSeparator.BackgroundColor = value; }
        }
        #endregion
        #region Title
        public Color TextColor
        {
            get { return DropdownTitle.TextColor; }
            set { this.DropdownTitle.TextColor = value; }
        }

        public Color DefaultTextColor { get; set; }  = (Color)Application.Current.Resources["CitoLight"];
        public Color SelectedTextColor { get; set; } = (Color)Application.Current.Resources["CitoMainLight"];

        public static BindableProperty TitleProperty = BindableProperty.Create(
            propertyName: nameof(Title),
            returnType: typeof(string),
            declaringType: typeof(DropdownItem),
            defaultBindingMode: BindingMode.TwoWay,
            defaultValue: string.Empty,
            propertyChanged: (b, o, n) => { ((DropdownItem)b).DropdownTitle.Text = (string)n; });


        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public TextAlignment TitleHorizontalTextAlignment
        {
            get { return DropdownTitle.HorizontalTextAlignment; }
            set
            {
                DropdownTitle.HorizontalTextAlignment = value;
                if (value == TextAlignment.Center)
                {
                    DropdownTitle.TranslationX = -10;
                }
            }
        }
        public TextAlignment TitleVerticalTextAlignment
        {
            get { return DropdownTitle.VerticalTextAlignment; }
            set { DropdownTitle.VerticalTextAlignment = value; }
        }
        #endregion
        #region Appearance
        public Color ColorBackground
        {
            get { return RootLayout.BackgroundColor; }
            set { RootLayout.BackgroundColor = value; }
        }
        public double ItemHeightRequest
        {
            get { return ItemLayout.HeightRequest; }
            set { ItemLayout.HeightRequest = value; }
        }

        internal Image Icon { get; set; }

        public enum Position
        {
            Left,
            Right
        }

        public Position ArrowPosition
        {
            set
            {
                if (value == Position.Left)
                {
                    Icon = LeftIcon;
                    LeftIcon.IsVisible = true;
                    RightIcon.IsVisible = false;
                }
                else if(value == Position.Right)
                {
                    Icon = RightIcon;
                    LeftIcon.IsVisible = false;
                    RightIcon.IsVisible = true;
                }
                else
                {
                    Icon = LeftIcon;
                    LeftIcon.IsVisible = true;
                    RightIcon.IsVisible = false;
                }
            }
        }

        #endregion
        #region ExpandableView
        public View ExpandableView
        {
            get { return ViewToExpand.Content; }
            set { ViewToExpand.Content = value; }
        }
        #endregion

        #endregion

        public DropdownItem()
        {
            InitializeComponent();
        }

        #region Methods

        private async void ItemTapped(object sender, EventArgs e)
        {
            if (ExpandableView == null) return;
            if (Icon == null) Icon = LeftIcon;


            if (!ViewToDisplay.IsVisible)
            {
                await Icon.RotateTo(180);
                ExpandableView.IsVisible = true;
                HandleImageButton();
                ViewToDisplay.IsVisible = true;
                Icon.Source = "DownArrowCito.png";
                DropdownTitle.TextColor = SelectedTextColor;
                await ViewToDisplay.FadeTo(1, easing: Easing.SpringIn);
            }
            else
            {
                await Icon.RotateTo(0);
                ExpandableView.IsVisible = false;
                ViewToDisplay.IsVisible = false;
                DropdownTitle.TextColor = DefaultTextColor;
                Icon.Source = "DownArrow.png";
                await ViewToDisplay.FadeTo(0, easing: Easing.SpringOut);
            }

        }

        private void HandleImageButton()
        {
            var listView = ((DropdownContent)ExpandableView).Content as ListView;
            listView?.ItemTemplate.CreateContent();
        }

        #endregion
    }

    public class DropdownContent : ContentView
    {
        #region Private properties

        #endregion
        #region Public properties

        #endregion
        public DropdownContent()
        {
            IsVisible = false;
        }

        #region Methods

        #endregion
    }
}
