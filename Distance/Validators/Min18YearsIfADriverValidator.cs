using Distance.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Distance.Validators
{
    public class Min18YearsIfADriverValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var driver = (DriverViewModels)validationContext.ObjectInstance;

            if (driver.AccountTypeId == 1)
                return ValidationResult.Success;

            if (driver.Birthdate == null)
                return new ValidationResult("Podaj datę urodzenia!");

            var age = DateTime.Today.Year - driver.Birthdate.Value.Year;

            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Kierowca musi być pełnoletni");
        }
    }
}