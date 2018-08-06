using Distance.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Distance.Validators
{
    public class NumberHouseValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult retval = new ValidationResult("");
            IAddressViewModel rvm = (IAddressViewModel)validationContext.ObjectInstance;
            bool isCorrect = true;
            if (rvm.HouseNumber != null)
                foreach (char c in rvm.HouseNumber.Replace(" ",""))
                {
                    if (!char.IsLetterOrDigit(c))
                    {
                        isCorrect = false;
                        break;
                    }


                }

            if (!isCorrect)
                retval.ErrorMessage += "Numer domu może zawierać wyłącznie litery i cyfry. ";

            return string.IsNullOrEmpty(retval.ErrorMessage) ? ValidationResult.Success : retval;
        }
    }
}