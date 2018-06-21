using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Distance.Models;

namespace Distance.ViewModels
{
    public class RandomCarViewModel
    {
        public Car Car { get; set; }
        public List<Driver> Drivers { get; set; }

    }
}