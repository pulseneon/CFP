using System.ComponentModel.DataAnnotations;

namespace CFP.Application.Attributes
{
    public class AnyFieldRequiredAttribute : ValidationAttribute
    {
        private readonly List<string> skippedProperties = new List<string>()
        {
            "Author"
        };

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var objectType = validationContext.ObjectInstance.GetType();

            var properties = objectType.GetProperties().Where(prop => prop.CanRead);

            foreach (var property in properties)
            {
                var propertyName = property.Name;

                if (skippedProperties.Contains(propertyName))
                {
                    continue;
                }

                var propertyValue = property.GetValue(validationContext.ObjectInstance);

                if (propertyValue != null && !string.IsNullOrEmpty(propertyValue.ToString()))
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(ErrorMessage ?? "At least one field is required.");
        }
    }
}
