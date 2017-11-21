using System;
using System.Collections.Generic;
using System.Text;
using Acr.UserDialogs;
using Cito.Framework.Controls;
using Cito.Framework.Utilities;
using Cito.Framework.Validation;
using Cito.Helpers;
using Cito.ViewModels;
using Cito.Views;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cito
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : Application
    {
        #region Private properties
        private static ViewModelLocator _locator;
        internal static StackLayout ScrollParent;
        internal static CitoEntry FocusedEntry;
        #endregion
        #region Public properties
        public static ViewModelLocator Locator => _locator ?? (_locator = new ViewModelLocator());
        public static ValidationFieldList ValidationFieldList;
        public static Type InstantiatingPageType;
        public static Page RootPage;
        public static NavigationPage NavPage;
        public static MasterDetailPage MenuPage;
        public static bool LoadingInProgress;
        #endregion

        public App()
        {
            InitializeComponent();
            ValidationFieldList = new ValidationFieldList();
            Device.BeginInvokeOnMainThread(async () => await Location.GetUserLocation()); 

            Connectivity.CheckConnectionAndDisplayToast();

            if (App.Locator.Prelogin.Settings.IsUserLoggedIn)
            {
                if (App.Locator.Prelogin.Settings.UserType.Equals(UserTypeViewModel.UserTypeOf.Owner.ToString()))
                {
                    var rootPage = new MapPage();
                    App.NavPage = new NavigationPage(rootPage);
                    App.MenuPage = (MasterDetailPage)new OwnerMenu() { Detail = App.NavPage };
                    App.Current.MainPage = App.MenuPage;
                }
                else
                {
                    var rootPage = new AvailabiltyPage();
                    App.NavPage = new NavigationPage(rootPage);
                    App.MenuPage = (MasterDetailPage)new WasherMenu() { Detail = App.NavPage };
                    App.Current.MainPage = App.MenuPage;
                }
            }
            else
            {
                InstantiatingPageType = typeof(PreloginPage);
                NavPage = new NavigationPage(new PreloginPage());
                MainPage = NavPage;
            }
        }



        #region Methods

        public static void UpdateLoading(bool isLoading, string text = null)
        {
            try
            {
                LoadingInProgress = isLoading;

                if (LoadingInProgress)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        UserDialogs.Instance.ShowLoading(text, MaskType.Gradient);
                        //DependencyService.Get<IStayAwake>().Set(true);
                    });                 
                }
                else
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        UserDialogs.Instance.HideLoading();
                        //DependencyService.Get<IStayAwake>().Set(false);
                    });
                }
            }
            catch (Exception e)
            {
                // ignored
            }           
        }

        #endregion
        #region Validation methods
        //public static INavigation navigation;
        public static bool FormValidationPassed(bool displayValidationFailureList = true)
        {
            var invalidFields = GetInvalidFields();
            if (invalidFields.Count == 0)
                return true;

            if (!displayValidationFailureList) return false;

            var firstMessage = string.Empty;
            var sb = new StringBuilder("Validation errors:" + Environment.NewLine);
            foreach (var validationResult in invalidFields)
            {
                if (string.IsNullOrEmpty(firstMessage))
                {
                    firstMessage = validationResult.FieldName;
                }
                sb.Append(validationResult.FieldName + " " + validationResult.ValidationError + Environment.NewLine);
            }

            //navigation.PushPopupAsync(new BaseErrorPopup(TextRes.error, firstMessage));
            Current.MainPage.DisplayAlert("Error", firstMessage, "OK");

            return false;
        }
        public static List<ValidationResult> GetInvalidFields()
        {
            return ValidationFieldList.InvalidFields();
        }

        public static void UnloadPage(Page page)
        {
            ValidationFieldList.RemoveFieldsForPage(page.GetType());
        }
        
        #endregion
        #region App overrides

        protected override void OnStart()
        {
            //Location.CurrentPosition = new Position(CitoSettings.Current.LastLatitude, CitoSettings.Current.LastLatitude);            
        }

        protected override void OnSleep()
        {
            if (App.Locator.Prelogin.Settings.IsUserLoggedIn)
                Location.StopGps();
        }

        protected override void OnResume()
        {
            FocusedEntry?.Unfocus();
            if (App.Locator.Prelogin.Settings.IsUserLoggedIn)
                Device.BeginInvokeOnMainThread(async () => await Location.GetUserLocation());
        }

        #endregion
    }
}
