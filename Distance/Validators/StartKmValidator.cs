﻿using Distance.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Distance.Validators
{
    public class StartKmValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult retval = new ValidationResult("");
            TravelViewModels rvm = (TravelViewModels)validationContext.ObjectInstance;
            bool isCorrect = true;
            if (rvm.StartKm != null)
                foreach (char c in rvm.StartKm)
                {
                    if (!char.IsDigit(c))
                    {
                        isCorrect = false;
                        break;
                    }

                }

            if (!isCorrect)
                retval.ErrorMessage += "Przebieg jest liczbą. ";

            return string.IsNullOrEmpty(retval.ErrorMessage) ? ValidationResult.Success : retval;
        }
    }
}