﻿using Distance.Controllers;
using Distance.Models;
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
            DatabaseControler dc = new DatabaseControler();
            Cars car = dc.GetCarDatabaseModelById(rvm.CarId);
            if (!isCorrect)
                retval.ErrorMessage += "Przebieg jest liczbą. ";
            if(rvm.StartKm!=null && isCorrect && int.Parse(rvm.StartKm)<car.KmAge)
                retval.ErrorMessage += "Przebieg przed podróżą nie może być mniejszy niż aktualny przebieg pojazdu. Aktualny przebieg to: "+car.KmAge+" km. ";

            return string.IsNullOrEmpty(retval.ErrorMessage) ? ValidationResult.Success : retval;
        }
    }
}