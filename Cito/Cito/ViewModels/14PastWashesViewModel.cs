using System.Collections.Generic;
using Cito.Models;

namespace Cito.ViewModels
{
    public class PastWashesViewModel : CitoViewModelBase
    {


        #region Bindable properties

        private List<PastWashes> _pastWashesList;
        public List<PastWashes> PastWashesList
        {
            get { return _pastWashesList; }
            set { Set(ref _pastWashesList, value); }
        }

        #endregion
        #region Commands


        #endregion

        public PastWashesViewModel()
        {
            PastWashesList = new List<PastWashes>()
            {
                new PastWashes("June", new List<PastWasherDetails>()
                {
                    new PastWasherDetails("WasherProfileImage.jpg", "Washer Name", 5, "12.99$"),
                    new PastWasherDetails("WasherProfileImage.jpg", "Washer Name", 3, "12.99$")
                }),
                new PastWashes("May"),
                new PastWashes("April"),
                new PastWashes("March")
            };
        }

        #region Methods


        #endregion

    }
}
