using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Distance.Models;

namespace Distance.ViewModels
{
    public class NewCarViewModel
    {
        public IEnumerable<CarStatus> CarStatuses { get; set; }

        public int? Id { get; set; } //id
    
        [Required]
        [Display(Name = "Marka")]
        public string Name { get; set; } //marka auta

        [Required]
        [Display(Name = "Model")]
        public string Model { get; set; } //model auta

        [Required]
        [Display(Name = "Rejestracja")]
        public string CarPlate { get; set; } //numer rejestracji

        [Required]
        [Display(Name = "Przebieg")]
        public int KmAge { get; set; } //przebieg w km

        [Display(Name = "Status samochodu")]
        [Required]
        public byte? CarStatusId { get; set; } //FK dla CarStatus

        public string Title
        {
            get
            {
                if (Id != 0)
                    return "Edytuj samochód";

                return "Dodaj nowy Samochód";
            }
        }

        public NewCarViewModel()
        {
            Id = 0;     
        }

        public NewCarViewModel(Car car)
        {
            Id = car.Id;
            Name = car.Name;
            Model = car.Model;
            CarPlate = car.CarPlate;
            KmAge = car.KmAge;
            CarStatusId = car.CarStatusId;
        }

    }
}