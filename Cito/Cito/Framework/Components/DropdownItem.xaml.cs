using System;
using Xamarin.Forms;

namespace Cito.Framework.Components
{
    public class DropdownContent : ContentView
    {
        public DropdownContent()
        {
            IsVisible = false;
        }
    }

    public partial class DropdownItem : ContentView
    {
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
     
        public DropdownItem()
        {
            InitializeComponent();
        }

        private async void ItemTapped(object sender, EventArgs e)
        {
            if (!ViewToDisplay.IsVisible)
            {
                await Icon.RotateTo(90);
                ViewToDisplay.IsVisible = true;
                if (ExpandableView != null) ExpandableView.IsVisible = true;
                await ViewToDisplay.FadeTo(1);
            }
            else
            {
                await Icon.RotateTo(-90);
                ViewToDisplay.IsVisible = false;
                if (ExpandableView != null) ExpandableView.IsVisible = false;
                await ViewToDisplay.FadeTo(0);
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
    }
}
