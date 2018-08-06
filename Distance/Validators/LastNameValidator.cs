using Distance.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Distance.Validators
{
    public class LastNameValidator:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult retval = new ValidationResult("");
            IPersonalDataViewModels rvm = (IPersonalDataViewModels)validationContext.ObjectInstance;
            bool isCorrect = true;
            if (rvm.LastName != null)
                foreach (char c in rvm.LastName)
                {
                    if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                    {
                        isCorrect = false;
                        break;
                    }


                }

            if (!isCorrect)
                retval.ErrorMessage += "Podane nazwisko jest niepoprawne. ";

            return string.IsNullOrEmpty(retval.ErrorMessage) ? ValidationResult.Success : retval;
        }
    }
}