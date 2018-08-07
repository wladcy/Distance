using Distance.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Distance.Validators
{
    public class FromValidator: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult retval = new ValidationResult("");
            TravelViewModels rvm = (TravelViewModels)validationContext.ObjectInstance;
            bool isCorrect = true;
            if (rvm.From != null)
                foreach (char c in rvm.From)
                {
                    if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                    {
                        isCorrect = false;
                        break;
                    }


                }

            if (!isCorrect)
                retval.ErrorMessage += "Początek podróży to nazwa miejscowości. ";

            return string.IsNullOrEmpty(retval.ErrorMessage) ? ValidationResult.Success : retval;
        }

    }
}