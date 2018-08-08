using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Distance.Models;

namespace Distance.Dtos
{
    public class DriverDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public string FlatNumber { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string Id { get; set; }
    }
}