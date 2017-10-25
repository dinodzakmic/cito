using Xamarin.Forms;

namespace Cito.Framework.Components
{
    public partial class RoundedBoxView : BoxView
    {
        #region Private properties

        #endregion
        #region Public properties
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(BoxView), 0.0);

        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        #endregion
        public RoundedBoxView()
        {
            InitializeComponent();
        }

        #region Methods

        #endregion
    }
}
