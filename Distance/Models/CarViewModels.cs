using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Distance.Models
{
    public class CarViewModels
    {
        public int Id { get; set; } //id

        [Display(Name = "Marka")]
        public string Name { get; set; } //marka auta

        [Display(Name = "Model")]
        public string Model { get; set; } //model auta

        [Display(Name = "Rejestracja")]
        public string CarPlate { get; set; } //numer rejestracji

        [Display(Name = "Przebieg")]
        public int KmAge { get; set; } //przebieg w km

        
        public CarStatusViewModels CarStatus { get; set; }

        [Display(Name = "Status samochodu")]
        [Required]
        public byte CarStatusId { get; set; } //FK dla CarStatus
    }
}