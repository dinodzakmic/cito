using System.Collections.Generic;

namespace Cito.ViewModels
{
    public class OwnerProfileViewModel : CitoViewModelBase
    {
        #region Bindable properties
        #region FullName
        private string _fullName;

        public string FullName
        {
            get { return _fullName; }
            set { Set(ref _fullName, value); }
        }
        #endregion
        #region CarsList
        private List<string> _carsList;

        public List<string> CarsList
        {
            get { return _carsList; }
            set { Set(ref _carsList, value); }
        }
        #endregion
        #endregion
        #region Commands


        #endregion

        public OwnerProfileViewModel()
        {
            FullName = "Firstname Lastname";
            CarsList = new List<string>()
            {
                "Car1",
                "Car2"
            };
        }

        #region Methods


        #endregion

    }
}
