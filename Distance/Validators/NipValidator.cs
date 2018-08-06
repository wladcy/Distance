using Distance.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Distance.Validators
{
    public class NipValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //TODO unique values
            ValidationResult retval = new ValidationResult("");
            CompanyViewModel rvm = (CompanyViewModel)validationContext.ObjectInstance;
            bool isCorrect = true;
            int digit = 0;
            if (rvm.NIP != null)
                foreach (char c in rvm.NIP)
                {
                    if (!char.IsDigit(c) && !char.IsWhiteSpace(c) && !c.Equals("-"))
                    {
                        isCorrect = false;
                        break;
                    }
                    if (char.IsDigit(c))
                    {
                        digit++;
                    }
                }

            if (!isCorrect)
                retval.ErrorMessage += "Numer NIP składa się wyłącznie z cyfr. ";
            if (digit != 10)
                retval.ErrorMessage += "Numer NIP składa się z dziesięciu cyfr";

            return string.IsNullOrEmpty(retval.ErrorMessage) ? ValidationResult.Success : retval;
        }
    }
}