namespace Cito.Framework.Validation
{
    public class ValidationResult
    {
        public bool Valid;
        public string FieldName;
        public string ValidationError;

        public ValidationResult(string fieldName, bool valid, string validationError)
        {
            FieldName = fieldName;
            Valid = valid;
            ValidationError = validationError;
        }

        public ValidationResult(string fieldName)
        {
            FieldName = fieldName;
            Valid = false;
            ValidationError = "";
        }
    }
}
