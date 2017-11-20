using System;
using Cito.Framework.Utilities;
using Cito.Localization;
using Xamarin.Forms;

namespace Cito.Framework.Controls
{
    public partial class CitoLabel : Label
    {
        #region Private properties

        #endregion
        #region Public properties
        #region UpperCase

        public static BindableProperty UpperCaseProperty = BindableProperty.Create(
            "UpperCase",
            typeof(bool),
            typeof(CitoLabel),
            false,
            BindingMode.Default);

        public bool UpperCase
        {
            get { return (bool)GetValue(UpperCaseProperty); }
            set { SetValue(UpperCaseProperty, value); }
        }

        #endregion
        #region TText

        public static BindableProperty TTextProperty = BindableProperty.Create(
            "TText",
            typeof(string),
            typeof(CitoLabel),
            "",
            BindingMode.Default);

        public string TText
        {
            get { return (string)GetValue(TTextProperty); }
            set { SetValue(TTextProperty, value); }
        }

        #endregion
        #region Text

        public new static BindableProperty TextProperty = BindableProperty.Create(
            "Text",
            typeof(string),
            typeof(CitoLabel),
            "",
            BindingMode.Default,
            propertyChanged: (b, o, n) =>
            {
                if (string.IsNullOrEmpty((string)n))
                {
                    ((Label)b).Text = string.Empty;
                }
                else
                {
                    ((CitoLabel)b).UpdateText();
                }
            });

        public new string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        #endregion

        #endregion
        public CitoLabel()
        {
            InitializeComponent();
            FontFamily = CitoFont.SetFont();
            LineBreakMode = LineBreakMode.WordWrap;
            BindingContextChanged += (s, e) => { UpdateText(); };
        }

        #region Methods
        protected virtual void UpdateText()
        {
            var label = (Label)this;

            if (!string.IsNullOrEmpty(TText))
            {
                if (string.IsNullOrEmpty(Text))
                {
                    try
                    {
                        Text = TextResources.ResourceManager.GetString(TText);
                    }
                    catch
                    {
#if DEBUG
                        throw new ArgumentException($"Key '{Text}' was not found in resources.");
#else
                        Text = TText;
#endif
                    }
                }
            }
            var textToParse = Text;
            if (string.IsNullOrEmpty(textToParse)) return;
            if (UpperCase)
                textToParse = textToParse.ToUpper();

            label.Text = textToParse;
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            switch (propertyName)
            {
                case "UpperCase":
                case "TextColor":
                case "TText":
                    UpdateText();
                    break;
            }
        }

        #endregion
    }
}
