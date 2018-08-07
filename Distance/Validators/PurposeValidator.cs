using Distance.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Distance.Validators
{
    public class PurposeValidator:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult retval = new ValidationResult("");
            TravelViewModels rvm = (TravelViewModels)validationContext.ObjectInstance;
            bool isCorrect = true;
            if (rvm.Purpose != null)
                foreach (char c in rvm.Purpose)
                {
                    if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                    {
                        isCorrect = false;
                        break;
                    }


                }

            if (!isCorrect)
                retval.ErrorMessage += "Cel podróży zawiera niepoprawne znaki. ";

            return string.IsNullOrEmpty(retval.ErrorMessage) ? ValidationResult.Success : retval;
        }
    }
}