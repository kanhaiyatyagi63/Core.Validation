using System.ComponentModel.DataAnnotations;

namespace Core.Validation.Attributes
{
    public class DateTimeAttribute : ValidationAttribute
    {
        public string? _errorMessage = string.Empty;
        public DateTimeAttribute(string? errorMessage = null)
        {
            _errorMessage = errorMessage ?? string.Empty;
        }
        protected override ValidationResult IsValid(object currentValue, ValidationContext validationContext)
        {
            if (currentValue == null)
            {
                return new ValidationResult(GetErrorMessage());
            }
            var value = currentValue.ToString();
            if (string.IsNullOrEmpty(value) ||
                value.Length != 8 ||
                !DateTime.TryParseExact(value, "MMddyyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out _))
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }

        private string GetErrorMessage()
        {
            return _errorMessage ?? "DateTime is required!";
        }
    }
}
