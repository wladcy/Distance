using Distance.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Distance.Validators
{
    public class FirstNameValidator:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult retval = new ValidationResult("");
            IPersonalDataViewModels rvm = (IPersonalDataViewModels)validationContext.ObjectInstance;
            bool isCorrect = true;
            if (rvm.FirstName != null)
                foreach (char c in rvm.FirstName)
                {
                    if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                    {
                        isCorrect = false;
                        break;
                    }


                }

            if (!isCorrect)
                retval.ErrorMessage += "Podane imie jest niepoprawne. ";

            return string.IsNullOrEmpty(retval.ErrorMessage) ? ValidationResult.Success : retval;
        }
    }
}