using Distance.App_Start;
using Distance.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Distance.Validators
{
    public class PasswordValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult retval = new ValidationResult("");
            RegisterViewModel rvm = (RegisterViewModel)validationContext.ObjectInstance;
            int nonLetterAndDigit = 0;
            int digit = 0;
            int upperCase = 0;
            int lowerCase = 0;
            foreach (char c in rvm.Password)
            {
                if (char.IsDigit(c))
                    digit++;
                else if (!char.IsLetterOrDigit(c))
                    nonLetterAndDigit++;
                else if (char.IsUpper(c))
                    upperCase++;
                else if (char.IsLower(c))
                    lowerCase++;
            }

            if (nonLetterAndDigit == 0 && PasswordIdentityConfig.REQUIRENONLETTERORDIGIT)
                retval.ErrorMessage += "Hasło powinno zawierać przynajmniej jeden znak niealfanumeryczny. ";
            if (digit == 0 && PasswordIdentityConfig.REQUIREDIGIT)
                retval.ErrorMessage += "Hasło powinno zawierać przynajmniej jedną cyfrę. ";
            if (upperCase == 0 && PasswordIdentityConfig.REQUIREUPPERCASE)
                retval.ErrorMessage += "Hasło powinno zawirać przynajmniej jedną dużą literę. ";
            if (lowerCase == 0 && PasswordIdentityConfig.REQUIRELOWERCASE)
                retval.ErrorMessage += "Hasło powinno zawieać przynajmniej jedną małą literę. ";

            return string.IsNullOrEmpty(retval.ErrorMessage) ? ValidationResult.Success : retval;

        }
    }
}
