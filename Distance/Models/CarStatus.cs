using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Distance.Models
{
    public class CarStatus
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string StatusName { get; set; }
    }
}