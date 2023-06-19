using System;
using System.ComponentModel.DataAnnotations;

namespace SignIn.Domain.Validations
{
    public class LegalAgeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime birthDate)
                return birthDate > DateTime.UtcNow.AddYears(-18) ? new ValidationResult("O usuário deve ter mais de 18 anos de idade") : ValidationResult.Success;

            return new ValidationResult("Uma data deve ser inserida");
        }
    }
}
