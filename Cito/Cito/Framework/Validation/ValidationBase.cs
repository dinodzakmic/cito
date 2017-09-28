using Xamarin.Forms;

namespace Cito.Framework.Validation
{
    public abstract class ValidationBase<T> : Behavior<T>, IValidatableBehavior where T : View
    {
        public string ValidationError { get; set; }

        public bool IsValid => ValidateField().Valid;
        public abstract ValidationResult ValidateField();

        protected ValidationBase()
        {

        }

        protected sealed override void OnAttachedTo(T view)
        {
            //Register with the central repository of Validation Fields
            App.ValidationFieldList.AddField(view);


            //call virtual method implemented by child classes to setup validation
            AttachToView(view);

            base.OnAttachedTo(view);
        }


        protected sealed override void OnDetachingFrom(T view)
        {
            //Unregister from the central repository of Validation Fields
            App.ValidationFieldList.RemoveField(view);

            //call virtual method imeplemented by child classes to cleanup
            DetatchFromView(view);

            base.OnDetachingFrom(view);
        }

        protected abstract void AttachToView(T view);


        protected abstract void DetatchFromView(T view);

        protected ValidationResult GetNewValidationResult(View view)
        {
            return new ValidationResult(Validation.GetFieldName(view));
        }
    }
}
