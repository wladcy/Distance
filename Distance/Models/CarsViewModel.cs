using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Distance.Models
{
    public class CarsViewModel
    {
        public IEnumerable<CarViewModels> CarList { get; set; }
        public bool IsAdministrator { get; set; }
        public bool IsSetCompany { get; set; }
    }
}