using Distance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Distance.Models.AddPhoneNumberViewModel;

namespace Distance.Controllers
{
    public class DatabaseControler
    {
        private ApplicationDbContext context;

        public DatabaseControler()
        {
            context = new ApplicationDbContext();
        }

        public List<DirectPhones> GetDirectPhoneNumbers()
        {
            List<DicCountries> list = context.DicCountries.ToList();
            List<DirectPhones> retval = new List<DirectPhones>();
            foreach(DicCountries dc in list)
            {
                DirectPhones dp = new DirectPhones();
                dp.Id = dc.CountryID;
                dp.Name = dc.CountryName;
                retval.Add(dp);
            }
            return retval;
        }
    }
}