using Distance.Controllers;
using Distance.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Distance.Validators
{
    public class RegistrationNumberValidator:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult retval = new ValidationResult("");
            CarViewModels rvm = (CarViewModels)validationContext.ObjectInstance;
            bool isCorrect = true;
            if (rvm.CarPlate != null)
                foreach (char c in rvm.CarPlate)
                {
                    if (!char.IsLetterOrDigit(c))
                    {
                        isCorrect = false;
                        break;
                    }


                }
            DatabaseControler dc = new DatabaseControler();

            if (!isCorrect)
                retval.ErrorMessage += "Numer rejestracyjny składa się z liter i cyfr. ";
            if (!rvm.IsEditMode && dc.IsCarInDatabase(rvm.CarPlate))
                retval.ErrorMessage += "Podany numer rejestracyjny jest zarejestrowany w naszej bazie. ";

            return string.IsNullOrEmpty(retval.ErrorMessage) ? ValidationResult.Success : retval;
        }
    }
}