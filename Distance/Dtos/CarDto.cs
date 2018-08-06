using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Distance.Models;

namespace Distance.Dtos
{
    public class CarDto
    {
        public int Id { get; set; } //id

        public string Name { get; set; } //marka auta

        public string Model { get; set; } //model auta

        public string CarPlate { get; set; } //numer rejestracji

        public int KmAge { get; set; } //przebieg w km

        public float EngineCapacity { get; set; }

        [Required]
        public byte CarStatusId { get; set; } //FK dla CarStatus
    }
}