
using System.ComponentModel.DataAnnotations;

namespace HousingEstateControlSystem.Common
{
    public static class DTOValidation
    {
        public static bool ValidateDTO<T>(T dto, out List<ValidationResult> results)
        {
            var validationContext = new ValidationContext(dto, serviceProvider: null, items: null);
            results = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, results, validateAllProperties: true);
        }
    }
}
