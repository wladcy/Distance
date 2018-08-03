using Distance.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Distance.Models
{
    public class CompanyViewModel
    {
        [Required]
        [Display(Name = "Nazwa firmy")]
        public string CompanyName { get; set; }

        [Display(Name = "Ulica")]
        public string CompanyStreet { get; set; }

        [Required]
        [NumberHouseValidator]
        [Display(Name = "Numer domu")]
        public string HouseNumber { get; set; }
        
        [NumberFlatValidator]
        [Display(Name = "Numer mieszkania")]
        public string FlatNumber { get; set; }

        [Required]
        [ZipCodeValidator]
        [Display(Name = "Kod pocztowy")]
        public string ZipCode { get; set; }

        [Required]
        [CityValidator]
        [Display(Name = "Miejscowość")]
        public string City { get; set; }

        [Required]
        [NipValidator]
        [Display(Name ="NIP")]
        public string NIP { get; set; }

        public bool IsSetCompany { get; set; }
        public bool IsAdministrator { get; set; }
    }
}