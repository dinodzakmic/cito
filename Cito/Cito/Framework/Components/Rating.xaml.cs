using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Cito.Framework.Components
{
    public partial class Rating : ContentView
    {
        #region Private properties

        #endregion
        #region Public properties
        public bool IsTapEnabled { get; set; } = false;

        public static BindableProperty RatingStarsProperty = BindableProperty.Create(
            propertyName: nameof(RatingStars),
            returnType: typeof(int),
            declaringType: typeof(Rating),
            defaultBindingMode: BindingMode.TwoWay,
            defaultValue: 0,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: (b, o, n) =>
            {
                var starsRating = (int)n;
                var oldStarsRating = (int)o;

                if (starsRating > 5) starsRating = 5;
                if (starsRating < 0) starsRating = 0;

                var starsStack = ((Rating)b).StarsStack;

                foreach (View t in starsStack.Children)
                {
                    ((Image)t).Source = starsRating-- > 0
                        ? "CitoStarFill"
                        : "CitoStarEmpty";
                }
            });

        public int RatingStars
        {
            get { return (int)GetValue(RatingStarsProperty); }
            set { SetValue(RatingStarsProperty, value); }
        }
        #endregion

        public Rating()
        {
            InitializeComponent();
        }

        #region Methods
        private void StarTapped(object sender, EventArgs e)
        {
            if (!IsTapEnabled) return;

            var starRating = Int32.Parse(((Image)sender).ClassId);
            RatingStars = starRating;
        }
        #endregion
    }
}
