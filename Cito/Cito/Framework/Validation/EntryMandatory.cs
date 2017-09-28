using Cito.Framework.Controls;

namespace Cito.Framework.Validation
{
    public class EntryMandatory : ValidationBase<CitoEntry>
    {
        private CitoEntry _entry;

        public EntryMandatory()
        {
            ValidationError = "Required";
        }

        public override ValidationResult ValidateField()
        {
            var validation = GetNewValidationResult(_entry);
            validation.Valid = !string.IsNullOrEmpty(_entry.Text);

            if (!validation.Valid)
            {
                validation.ValidationError = ValidationError;
            }

            return validation;
        }

        protected override void AttachToView(CitoEntry view)
        {
            _entry = view;
        }

        protected override void DetatchFromView(CitoEntry view)
        {
            _entry = null;
        }
    }
}
