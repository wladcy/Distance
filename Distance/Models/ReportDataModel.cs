using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Distance.Models
{
    public class ReportDataModel
    {
        public CompanyViewModel CompanyData { get; set; }
        public CarViewModels CarData { get; set; }
        public IEnumerable<DriverViewModels> DriversData { get; set; }
        public List<TravelViewModels> TravelsData { get; set; }
    }
}