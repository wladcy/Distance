using Distance.Validators;
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

        [RegistrationNumberValidator]
        [Display(Name = "Rejestracja")]
        public string CarPlate { get; set; } //numer rejestracji

        [Display(Name = "Przebieg")]
        public int KmAge { get; set; } //przebieg w km

        [Display(Name ="Pojemność silnika")]
        public float EngineCapacity { get; set; }
        
        public IEnumerable<CarStatuses> CarStatus { get; set; }


        public byte CarStatusId { get; set; } //FK dla CarStatus

        public string Title
        {
            get
            {
                if (Id != 0)
                    return "Edytuj samochód";

                return "Dodaj nowy Samochód";
            }
        }

        public string Button
        {
            get
            {
                if (Id != 0)
                    return "Edytuj";
                return "Dodaj";
            }
        }

        public bool InTravelWithCurrentUser { get; set; }
        public bool IsEditMode { get; set; }
    }
}