using Distance.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Distance.Models
{
    public class DriverViewModels
    {
        [Required]
        [StringLength(20)]
        [Display(Name = "Imie")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Display(Name = "Ulica")]
        public string Street { get; set; }

        [Required]
        [Display(Name = "Numer domu")]
        public string HouseNumber { get; set; }

        [Display(Name = "Numer mieszkania")]
        public string FlatNumber { get; set; }

        [Required]
        [Display(Name = "Kod pocztowy")]
        public string ZipCode { get; set; }

        [Required]
        [Display(Name = "Miejscowość")]
        public string City { get; set; }

        public string Id { get; set; }
    }
}