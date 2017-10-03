
namespace Cito.Framework.Validation
{
    public interface IValidatableBehavior
    {
        ValidationResult ValidateField();
        bool IsValid { get; }
    }
}
