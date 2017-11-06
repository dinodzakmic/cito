using System;
using Xamarin.Forms;

namespace Cito.Framework.Components
{
    public partial class DropdownItem : ContentView
    {
        #region Private properties

        #endregion
        #region Public properties
        public bool TopSeparatorVisible
        {
            get { return TopSeparator.IsVisible; }
            set { TopSeparator.IsVisible = value; }
        }
        public bool BottomSeparatorVisible
        {
            get { return BottomSeparator.IsVisible; }
            set { BottomSeparator.IsVisible = value; }
        }

        public string Title
        {
            get { return DropdownTitle.Text; }
            set { DropdownTitle.Text = value; }
        }

        public View ExpandableView
        {
            get { return ViewToExpand.Content; }
            set { ViewToExpand.Content = value; }
        }
        #endregion

        public DropdownItem()
        {
            InitializeComponent();
        }

        #region Methods

        private async void ItemTapped(object sender, EventArgs e)
        {
            if (!ViewToDisplay.IsVisible)
            {
                await Icon.RotateTo(90);
                if (ExpandableView != null) ExpandableView.IsVisible = true;
                ViewToDisplay.IsVisible = true;
                await ViewToDisplay.FadeTo(1, easing: Easing.SpringIn);
            }
            else
            {
                await Icon.RotateTo(-90);
                if (ExpandableView != null) ExpandableView.IsVisible = false;
                ViewToDisplay.IsVisible = false;
                await ViewToDisplay.FadeTo(0, easing: Easing.SpringOut);
            }

        }

        //protected bool DropdownCreated { get; set; } = false;
        //internal static int DropdownCounter { get; set; } = 0;
        //protected override void OnPropertyChanged(string propertyName = null)
        //{
        //    if (propertyName != null && propertyName.Equals("Content") && ViewToDisplay == null)
        //    {
        //        DropdownCounter++;

        //    }

        //    if (propertyName != null && propertyName.Equals("Content") && ViewToDisplay != null && !DropdownCreated)
        //    {
        //        ViewToDisplay.Content = Content;
        //        Content = RootLayout;
        //        DropdownCreated = true;
        //    }
        //}

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
