using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Distance.Models;

namespace Distance.Dtos
{
    public class DriverDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; } //imie

        [Required]
        [StringLength(30)]
        public string Surname { get; set; } //nazwisko

        //[Min18YearsIfADriver]
        public DateTime? Birthdate { get; set; } //data urodzenia

        //konto premium
        public bool IsPremiumAccount { get; set; }

        public byte AccountTypeId { get; set; } //FK dla AccountType
    }
}