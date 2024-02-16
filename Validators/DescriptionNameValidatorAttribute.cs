using System.ComponentModel.DataAnnotations;

namespace ProductsValidation.Validators
{
    public class DescriptionNameValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null) 
            {
                var description = value as string;

                var name = validationContext.ObjectType
                    .GetProperty("Name")
                    .GetValue(validationContext.ObjectInstance)
                    .ToString();

                if (name != null)
                {
                    bool isLengthOk = description.Length > 2 &&
                        description.Length > name.Length;

                    bool isContentsOk = description.StartsWith(name);

                    if (isLengthOk && isContentsOk)
                    {
                        return ValidationResult.Success;
                    }
                    else return new ValidationResult("Description must be longer than 2 characters, start with the product name and be longer than product name.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
