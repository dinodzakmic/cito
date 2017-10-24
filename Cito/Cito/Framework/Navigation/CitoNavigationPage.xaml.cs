using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cito.Framework.Navigation
{
    public partial class CitoNavigationPage : ContentPage
    {
        public bool BackgroundImageVisible { get; set; } = true;

        public Image CitoBackgroundImage
        {
            get { return CitoBackground; }
            set { CitoBackground = CitoBackgroundImage; }
        }
        public bool NavigationBarVisible { get; set; } = true;

        public Grid NavigationBar
        {
            get { return NavigationContent; }
            set { NavigationContent = value; }
        }

        public string CitoTitle
        {
            get { return TitleLabel.Text; }
            set { TitleLabel.Text = value; }
        }


        public ScrollView ScrollContent
        {
            get { return Scroll; }
            set { Scroll = value; }
        }
      

        public CitoNavigationPage()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            if (propertyName != null && propertyName.Equals("Content") && !CitoNavigation.PageInitialized && ScrollContent != null)
            {
                Scroll.Content = Content;
                CitoBackground.IsVisible = BackgroundImageVisible;
                NavigationContent.IsVisible = NavigationBarVisible;
                TitleLabel.Text = Title;
                Content = RootGrid;

                CitoNavigation.PageInitialized = true;
            }
        }

        protected virtual async void BackTapped(object sender, EventArgs e)
        {
           await CitoNavigation.PopPage();
        }

        public static bool IsMasterDisplayed { get; set; } = false;
        protected virtual async void MenuTapped(object sender, EventArgs e)
        {
            if (!IsMasterDisplayed)
            {
                MasterStack.IsVisible = true;
                await MasterStack.LayoutTo(new Rectangle(100 - MasterStack.TranslationX, 0, 600, 600), 250U, Easing.SinOut);

                IsMasterDisplayed = true;
            }
            else
            {
                MasterStack.IsVisible = false;
                await MasterStack.LayoutTo(new Rectangle(MasterStack.TranslationX - 100, 0, 600, 600), 250U, Easing.SinOut);

                IsMasterDisplayed = false;
            }

            //var mainPage = Application.Current.MainPage as MasterDetailPage;
            //if (mainPage != null)
            //{
            //    mainPage.IsPresented = !mainPage.IsPresented;
            //    //DarkStack.IsVisible = mainPage.IsPresented;
            //    //mainPage.IsPresentedChanged += (o, args) =>
            //    //{
            //    //    DarkStack.IsVisible = mainPage.IsPresented;
            //    //};
            //}
        }

        protected override bool OnBackButtonPressed()
        {
            Task.Run(async () => await CitoNavigation.PopPage()).Wait();
            return true;
        }

        internal List<double> XPoints { get; set; } = new List<double>();
        public virtual async void MenuSwipe(object sender, PanUpdatedEventArgs e)
        {
            double totalLeftX = 0;
            double totalRightX = 0;
            if (e.StatusType == GestureStatus.Running || e.StatusType == GestureStatus.Started)
            {
                XPoints.Add(e.TotalX);
                totalLeftX = -1 * MasterStack.TranslationX / 1.5 + 100 + e.TotalX;
                totalRightX = MasterStack.TranslationX / 1.5 + 100 + e.TotalX;
                if (totalLeftX < -700 || totalRightX > 700 || e.TotalX.Equals(0))
                {
                    return;
                }

                if (e.TotalX < 0)
                {
                    MasterStack.IsVisible = true;
                    await MasterStack.LayoutTo(
                        new Rectangle(-1 * MasterStack.TranslationX / 1.5 + 100 + e.TotalX, 0, 600, 600), 250U,
                        Easing.SinOut);
                    XPoints.RemoveAll(x => x > 0);
                    IsMasterDisplayed = true;
                }
                else
                {
                    MasterStack.IsVisible = true;
                    await MasterStack.LayoutTo(
                        new Rectangle(MasterStack.TranslationX / 2 + 100 + e.TotalX, 0, 600, 600), 250U,
                        Easing.SinOut);
                    XPoints.RemoveAll(x => x < 0);
                    IsMasterDisplayed = true;
                }
                return;
            }

            if (e.StatusType == GestureStatus.Completed)
            {
                if (IsMasterDisplayed)
                {
                    MasterStack.IsVisible = true;
                    await MasterStack.LayoutTo(new Rectangle(100 - MasterStack.TranslationX, 0, 600, 600), 250U, Easing.SinOut);
                    XPoints.Clear();
                    IsMasterDisplayed = true;
                }
                else
                {
                    MasterStack.IsVisible = false;
                    await MasterStack.LayoutTo(new Rectangle(MasterStack.TranslationX - 100, 0, 600, 600), 250U, Easing.SinOut);
                    XPoints.Clear();
                    IsMasterDisplayed = false;
                }
            }



        }
    }
}
