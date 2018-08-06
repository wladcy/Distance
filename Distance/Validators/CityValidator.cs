using Distance.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Distance.Validators
{
    public class CityValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult retval = new ValidationResult("");
            IAddressViewModel rvm = (IAddressViewModel)validationContext.ObjectInstance;
            bool isCorrect = true;
            if (rvm.City != null)
                foreach (char c in rvm.City)
                {
                    if (!char.IsLetter(c)&&!char.IsWhiteSpace(c))
                    {
                        isCorrect = false;
                        break;
                    }


                }

            if (!isCorrect)
                retval.ErrorMessage += "Nazwa miejscowości jest niepoprawna. ";

            return string.IsNullOrEmpty(retval.ErrorMessage) ? ValidationResult.Success : retval;
        }
    }
}