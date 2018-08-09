using Distance.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Distance.Validators
{
    public class PhoneNumberValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult retval = new ValidationResult("");
            IPhoneNumberViewModel checkValue = (IPhoneNumberViewModel)validationContext.ObjectInstance;
            string phone = checkValue.Number.Replace(" ", "");

            if (phone.Length != 9 && !checkValue.IsEditMode)
                retval.ErrorMessage += "Numer telefonu powinien składać się z 9 cyfr. ";

            return string.IsNullOrEmpty(retval.ErrorMessage) ? ValidationResult.Success : retval;

        }
    }
}