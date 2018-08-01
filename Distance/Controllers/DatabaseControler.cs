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
            List<DicCountries> list = context.DicCountries.OrderBy(c=>c.CountryCodeA3).ToList();
            List<DirectPhones> retval = new List<DirectPhones>();
            foreach(DicCountries dc in list)
            {
                DirectPhones dp = new DirectPhones();
                dp.Id = dc.CountryID;
                dp.Name = dc.CountryCodeA3+" +"+dc.CountryDirectPhoneNumber;
                retval.Add(dp);
            }
            return retval;
        }

        public string GetDirectPhoneNumber(int countryId)
        {
            string retval = string.Empty;
            DicCountries country = context.DicCountries.Where(c => c.CountryID == countryId).FirstOrDefault();
            if (country != null)
            {
                retval = "+" + country.CountryDirectPhoneNumber;
            }
            return retval;
        }

        public void GetCompany(ref CompanyViewModel model, string userId)
        {
            Company company = (from c in context.Company join u in context.UserInCompany on c.CompanyID equals u.CompanyId where u.UserId.Equals(userId) select c).FirstOrDefault();
            if (company != null && company.CompanyID != 0)
            {
                model.City = company.City;
                model.CompanyName = company.CompanyName;
                model.CompanyStreet = company.Street;
                model.FlatNumber = company.FlatNumber;
                model.HouseNumber = company.HouseNumber;
                model.IsSetCompany = true;
                model.ZipCode = company.ZipCode;
            }
            else{
                model.IsSetCompany = false;
            }
        }
    }
}