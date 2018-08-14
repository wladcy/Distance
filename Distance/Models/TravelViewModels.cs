using Distance.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Distance.Models
{
    public class TravelViewModels
    {
        [Required]
        [StartKmValidator]
        [Display(Name = "Przebieg samochodu przed podróżą")]
        public string StartKm { get; set; }

        [Required]
        [StopKmValidator]
        [Display(Name = "Przebieg samochodu po podróży")]
        public string StopKm { get; set; }

        [Required]
        [PurposeValidator]
        [Display(Name = "Cel podróży")]
        public string Purpose { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Uwagi")]
        public string Notes { get; set; }

        [Required]
        [FromValidator]
        [Display(Name = "Początek podróży (miescowość)")]
        public string From { get; set; }

        [Required]
        [ToValidator]
        [Display(Name = "Koniec podróży (miejscowość)")]
        public String To { get; set; }

        public string Title { get; set; }
        public string Button { get; set; }
        public int CarId { get; set; }
        public bool StartTravel { get; set; }
        public DateTime TravelDate { get; set; }
    }

    public class SelectDateViewModel
    {        
        public IEnumerable<DateViewModel> Mounth { get; set; }
        
        public IEnumerable<DateViewModel> Year { get; set; }

        public int CarId { get; set; }

        [Required]
        [Display(Name = "Miesiąc")]
        public int MonthId { get; set; }

        [Required]
        [Display(Name = "Rok")]
        public int YearId { get; set; }
    }

    public class DateViewModel
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}