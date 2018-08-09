using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Distance.Models
{
    public class DriversViewModels
    {
        public IEnumerable<DriverViewModels> Drivers { get; set; }
        public bool IsSetCompany { get; set; }
    }
}