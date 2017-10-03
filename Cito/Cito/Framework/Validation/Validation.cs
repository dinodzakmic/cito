using Cito.Framework.Controls;
using Cito.Localization;
using Xamarin.Forms;

namespace Cito.Framework.Validation
{
    public class Validation : BindableObject
    {
        public static readonly BindableProperty FieldNameProperty = BindableProperty.CreateAttached("field", typeof(string), typeof(Validation), null);

        public static string GetFieldName(BindableObject bindable)
        {
            var fieldName = (string)bindable.GetValue(FieldNameProperty);
            if (!string.IsNullOrEmpty(fieldName))
                return fieldName;

            var entry = bindable as CitoEntry;
            if (entry != null)
            {
                return entry.ErrorText;
            }

            return "field";
        }
    }
}
