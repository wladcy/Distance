using Distance.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Distance.Validators
{
    public class NumberFlatValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult retval = new ValidationResult("");
            CompanyViewModel rvm = (CompanyViewModel)validationContext.ObjectInstance;
            bool isCorrect = true;
            if (rvm.FlatNumber != null)
                foreach (char c in rvm.FlatNumber.Replace(" ",""))
                {
                    if (!char.IsLetterOrDigit(c))
                    {
                        isCorrect = false;
                        break;
                    }


                }

            if (!isCorrect)
                retval.ErrorMessage += "Numer mieszkania może zawierać wyłącznie litery i cyfry. ";

            return string.IsNullOrEmpty(retval.ErrorMessage) ? ValidationResult.Success : retval;
        }
    }
}