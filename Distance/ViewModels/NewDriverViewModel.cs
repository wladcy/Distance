using Distance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Distance.ViewModels
{
    public class NewDriverViewModel
    {
        public IEnumerable<AccountType> AccountTypes { get; set; }
        public Driver Driver { get; set; }

        public string Title
        {
            get
            {
                if (Driver != null && Driver.Id != 0)
                    return "Edytuj Kierowcę";

                return "Dodaj nowego kierowcę";
            }
        }

    }
}