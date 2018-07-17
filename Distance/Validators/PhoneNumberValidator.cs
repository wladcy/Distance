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
            AddPhoneNumberViewModel checkValue = (AddPhoneNumberViewModel)validationContext.ObjectInstance;
            string phone = checkValue.Number.Replace(" ", "");
            
            if (phone.Length!=9)
                retval.ErrorMessage += "Numer telefonu powinien składać się z 9 cyfer. ";

            return string.IsNullOrEmpty(retval.ErrorMessage) ? ValidationResult.Success : retval;

        }
    }
}