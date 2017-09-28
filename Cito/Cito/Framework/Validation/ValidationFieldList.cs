using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Cito.Framework.Validation
{
    public class ValidationFieldList
    {
        private readonly List<ViewInfo> _views = new List<ViewInfo>();

        public void AddField(View field)
        {
            Type pageType;

            //handle this

            //if (App.NavPage == null && App.InstantiatingPageType == null)
            //{
            //    pageType = typeof(CreateProfileStep1);
            //}
            //else
            //{
            //    pageType = App.InstantiatingPageType ?? App.CurrentPage.GetType();
            //}

            //_views.Add(new ViewInfo(field, pageType));
        }


        public int Count => _views.Count;

        //public bool AllFieldsValid
        //{
        //    get { return _views.Where(v => v.PageType == App.NavPage.CurrentPage.GetType()).All(v => v.View.Behaviors.All(b => !(b is IValidatableBehavior) || ((IValidatableBehavior)b).IsValid)); }
        //}

        public List<ValidationResult> InvalidFields()
        {
            var validationResults = new List<ValidationResult>();
            //foreach (var v in _views.Where(v => v.PageType == App.CurrentPage.GetType()))
            //{
            //    validationResults.AddRange(v.View.Behaviors.Where(b => b is IValidatableBehavior).Select(b => ((IValidatableBehavior)b).ValidateField()).ToList());
            //}
            return validationResults.Where(v => !v.Valid).ToList();
        }


        #region Remove field(s) methods

        public void RemoveField(View field)
        {
            for (int i = 0; i < _views.Count; i++)
            {
                if (_views[i].View != field) continue;

                _views.RemoveAt(i);
                i--;
            }
        }

        public void RemoveAllFields()
        {
            _views.Clear();
        }

        public void RemoveFieldsForPage(Type pageType)
        {
            for (int i = 0; i < _views.Count; i++)
            {
                if (_views[i].PageType == pageType)
                {
                    _views.RemoveAt(i);
                    i--;
                }
            }
        }
        #endregion
        #region ViewInfo class
        private class ViewInfo
        {
            public readonly View View;
            public readonly Type PageType;

            public ViewInfo(View view, Type pageType)
            {
                View = view;
                PageType = pageType;
            }
        }
        #endregion

    }
}
