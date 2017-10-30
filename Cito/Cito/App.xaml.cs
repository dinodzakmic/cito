using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cito.Framework.Validation;
using Cito.ViewModels;
using Cito.Views;
using Xamarin.Forms;

namespace Cito
{  
    public partial class App : Application
    {
        #region Private properties
        private static ViewModelLocator _locator;
        #endregion
        #region Public properties
        public static ViewModelLocator Locator => _locator ?? (_locator = new ViewModelLocator());
        public static ValidationFieldList ValidationFieldList;
        public static Type InstantiatingPageType;
        public static NavigationPage NavPage;
        #endregion

        public App()
        {
            InitializeComponent();
            ValidationFieldList = new ValidationFieldList();

            var detail = new NavigationPage(new MapPage());
            MainPage = new Menu() {Detail = detail};
            NavPage = detail;
        }

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
        public static void UpdateLoading(bool isLoading, string text = "")
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                //if (isLoading)
                //    UserDialogs.Instance.ShowLoading(text.IsNotNullOrEmpty() ? text : TextRes.Loading___, MaskType.Black);
                //else
                //    UserDialogs.Instance.HideLoading();
            });
        }
        #endregion
        #region App overrides

        protected override void OnStart()
        {
            // Handle when your app starts
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {            
            // Handle when your app resumes           
        }

        #endregion
    }
}
