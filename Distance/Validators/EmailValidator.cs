using Distance.Controllers;
using Distance.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Distance.Validators
{
    public class EmailValidator:ValidationAttribute 
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult retval = new ValidationResult("");
            IPersonalDataViewModels rvm = (IPersonalDataViewModels)validationContext.ObjectInstance;
            if (rvm.Email != null)
            {
                DatabaseControler dc = new DatabaseControler();
                if (dc.IsMailInDatabase(rvm.Email)&&!rvm.IsEditMode)
                    retval.ErrorMessage += "Użytkownik o podanym adresie mail istnieje w naszej bazie. ";
            }
            
            return string.IsNullOrEmpty(retval.ErrorMessage) ? ValidationResult.Success : retval;
        }
    }
}