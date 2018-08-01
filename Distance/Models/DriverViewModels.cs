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
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Imie")]
        public string Name { get; set; } //imie

        [Required]
        [StringLength(30)]
        [Display(Name = "Nazwisko")]
        public string Surname { get; set; } //nazwisko

        [Display(Name = "Data urodzenia")]
        [Min18YearsIfADriverValidator]
        public DateTime? Birthdate { get; set; } //data urodzenia

        //konto premium
        public bool IsPremiumAccount { get; set; }

        public AccountTypeViewModels AccountType { get; set; }

        [Display(Name = "Typ konta")]
        public byte AccountTypeId { get; set; } //FK dla AccountType
    }
}