using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cito.Framework.Validation;
using Cito.Localization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cito.Framework.Controls
{
    public partial class CitoEntry : Entry
    {
        public View ScrollParent { get; set; }
        public double KeyboardHeight { get; set; } = 200;
        public CitoEntry()
        {
            InitializeComponent();
            FontFamily = Device.OnPlatform(
                "Lato",
                null,
                @"/Assets/Fonts/Lato-Regular.ttf#Lato"
            );

            BindingContextChanged += (s, e) => { UpdateText(); };

        }
      
        #region NextView
        public static readonly BindableProperty NextViewProperty =
            BindableProperty.Create("NextView", typeof(View), typeof(CitoEntry));

        public View NextView
        {
            get { return (View) GetValue(NextViewProperty); }
            set { SetValue(NextViewProperty, value); }
        }

        public void OnNext()
        {
            NextView?.Focus();
        }
        #endregion
        #region Focused/Unfocused methods       
        private void CitoEntryUnfocused(object sender, FocusEventArgs e)
        {
            var scrollParent = ScrollParent as StackLayout;
            scrollParent?.Children.RemoveAt(scrollParent.Children.Count - 1);
        }

        private void CitoEntryFocused(object sender, FocusEventArgs e)
        {
            var scrollParent = ScrollParent as StackLayout;
            scrollParent?.Children.Add(new StackLayout() {HeightRequest = KeyboardHeight});
        }
        #endregion
        #region FirstLetterUpperCase
        public static BindableProperty FirstLetterUpperCaseProperty = BindableProperty.Create(
           "IsFirstLetterUpperCase",
           typeof(bool),
           typeof(CitoEntry),
           false,
           BindingMode.TwoWay
           );


        private bool _isFirstLetterUpperCase;

        public bool IsFirstLetterUpperCase
        {
            get { return _isFirstLetterUpperCase; }
            set
            {
                _isFirstLetterUpperCase = value;
                SetValue(FirstLetterUpperCaseProperty, value);
            }
        }
        #endregion
        #region AutoCorrect
        public static BindableProperty AutoCorrectEnabledProperty = BindableProperty.Create(
           "IsFirstLetterUpperCase",
           typeof(bool),
           typeof(CitoEntry),
           true,
           BindingMode.TwoWay
           );

        private bool _isAutoCorrectEnabled = true;

        public bool IsAutoCorrectEnabled
        {
            get { return _isAutoCorrectEnabled; }
            set
            {
                _isAutoCorrectEnabled = value;
                SetValue(AutoCorrectEnabledProperty, value);
            }
        }
        #endregion
        #region ErrorText
                private string _errorText;

                public string ErrorText
                {
                    get { return _errorText; }
                    set
                    {
                        _errorText = value;
                        OnPropertyChanged("ErrorText");
                    }
                }
        #endregion
        #region Validation properties and methods
        private bool _mandatory;
        public bool Mandatory
        {
            get { return _mandatory; }
            set
            {
                _mandatory = value;
                ToggleValidationBehavior();
            }
        }

        protected virtual void ToggleValidationBehavior()
        {
            if (Mandatory && Behaviors.Where(b => b is EntryMandatory).ToArray().Length == 0)
            {
                Behaviors.Add(new EntryMandatory());
            }
            else
            {
                var behavior = Behaviors.FirstOrDefault(b => b is EntryMandatory);
                if (behavior != null)
                {
                    Behaviors.Remove(behavior);
                }
            }
        }
        #endregion
        #region OnPropertyChanged

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            switch (propertyName)
            {
                case "TextColor":
                case "PlaceholderColor":
                case "TPlaceholder":
                    UpdateText();
                    break;
            }
        }

        #endregion
        #region UpdateText

        protected virtual void UpdateText()
        {
            var label = (Entry)this;

            if (!string.IsNullOrEmpty(TPlaceholder))
            {
                if (string.IsNullOrEmpty(Placeholder))
                {
                    try
                    {
                        Placeholder = TextResources.ResourceManager.GetString(TPlaceholder);
                    }
                    catch
                    {
#if DEBUG
                        throw new ArgumentException($"Key '{Placeholder}' was not found in resources.");
#else
                        Placeholder = TPlaceholder;
#endif
                    }
                }
            }
            var textToParse = Placeholder;
            if (string.IsNullOrEmpty(textToParse)) return;
            label.Placeholder = textToParse;
        }

        #endregion
        #region TPlaceholder
        public static BindableProperty TPlaceholderProperty = BindableProperty.Create(
           "TPlaceholder",
           typeof(string),
           typeof(CitoLabel),
           "",
           BindingMode.Default);

        public string TPlaceholder
        {
            get { return (string)GetValue(TPlaceholderProperty); }
            set { SetValue(TPlaceholderProperty, value); }
        }
        #endregion
        #region MaximumLength
        private int _maximumLength;
        public int MaximumLength
        {
            get
            {
                return _maximumLength;
            }
            set
            {
                _maximumLength = value;
            }
        }
        #endregion
        #region TextChanged

        private void NEntry_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;

            if (MaximumLength <= 0) return;
            if (entry.Text.Length <= 0) return;
            if (entry.Text.Length > MaximumLength)
                if (e.OldTextValue != null)
                    entry.Text = e.OldTextValue;
                else entry.Text = "";
        }

        #endregion
    }
}
