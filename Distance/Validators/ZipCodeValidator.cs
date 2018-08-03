using Distance.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Distance.Validators
{
    public class ZipCodeValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult retval = new ValidationResult("");
            CompanyViewModel rvm = (CompanyViewModel)validationContext.ObjectInstance;
            bool isCorrect = true;
            if (rvm.ZipCode != null)
                isCorrect = Regex.IsMatch(rvm.ZipCode, "^[0-9]{2}-[0-9]{3}$");
            if (!isCorrect)
                retval.ErrorMessage += "Kod pocztowy jest niepoprawny. ";

            return string.IsNullOrEmpty(retval.ErrorMessage) ? ValidationResult.Success : retval;
        }
    }
}