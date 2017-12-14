using System.Collections.Generic;
using Cito.Framework.Helpers;

namespace Cito.ViewModels
{
    public class OwnerProfileViewModel : CitoViewModelBase
    {
        #region Bindable properties
        #region FullName

        public string FullName => CitoSettings.Current.FullName;
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
            var realCar = CitoSettings.Current.CarModel;
            CarsList = new List<string>()
            {
                realCar,
                "Car2"
            };
        }

        #region Methods


        #endregion

    }
}
