using System.Collections.Generic;
using Cito.Models;

namespace Cito.ViewModels
{
    public class FutureWashesViewModel : CitoViewModelBase
    {
        #region Bindable properties

        private List<FutureWashes> _futureWashesList;
        public List<FutureWashes> FutureWashesList
        {
            get { return _futureWashesList; }
            set { Set(ref _futureWashesList, value); }
        }

        #endregion
        #region Commands


        #endregion

        public FutureWashesViewModel()
        {
            FutureWashesList = new List<FutureWashes>()
            {
                new FutureWashes("September"),
                new FutureWashes("October", new List<FutureWashDetails>()
                {
                    new FutureWashDetails("Car", "11/10/2018", "Bentley Continental GT", "Elite Pack", "**** **** **** 1528"),
                    new FutureWashDetails("Car", "20/10/2018", "Porsche Cayenne S", "Elite Pack", "**** **** **** 1528")
                }),
                new FutureWashes("November"),
                new FutureWashes("December")
            };
        }

        #region Methods


        #endregion
    }
}
