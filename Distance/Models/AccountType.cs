using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Distance.Models
{
    public class AccountType
    {
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; } //typ konta

        public short SignUpFee { get; set; } //opłata za konto
        public byte DurationInMonths { get; set; } //czas trwania premium
        public byte DiscountRate { get; set; } // wielkość zniżki



    }
}