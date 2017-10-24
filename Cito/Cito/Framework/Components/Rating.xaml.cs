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
        public BindableProperty RatingStarsProperty = BindableProperty.Create(
            propertyName: nameof(RatingStars),
            returnType: typeof(int),
            declaringType: typeof(Rating),
            defaultValue: 0,
            propertyChanged: (b, o, n) =>
            {
                var starsRating = (int)n;
                if (starsRating > 5) starsRating = 5;
                if (starsRating < 0) starsRating = 0; 

                var starsStack = ((Rating) b).StarsStack;

                foreach (View t in starsStack.Children)
                {
                    ((Image)t).Source = starsRating-- > 0 
                                      ? "CitoStarFill"
                                      : "CitoStarEmpty";  
                }
            });

        public int RatingStars
        {
            get { return (int) GetValue(RatingStarsProperty); }
            set { SetValue(RatingStarsProperty, value); }
        }

        public Rating()
        {
            InitializeComponent();
        }

    }
}
