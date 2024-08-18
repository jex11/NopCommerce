using System.ComponentModel.DataAnnotations;

namespace Nop.Web.Areas.Admin.Validators.Book
{
    public class CustomerBookValidator : ValidationAttribute
    {
        private readonly string _prefix;

        public CustomerBookValidator(string prefix)
        {
            _prefix = prefix;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string strValue && !strValue.StartsWith(_prefix))
            {
                return new ValidationResult($"The field {validationContext.DisplayName} must start with '{_prefix}'.");
            }

            return ValidationResult.Success;
        }
    }
}
