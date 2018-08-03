using Distance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
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

        public Company GetCompany(ref CompanyViewModel model, string userId)
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
                model.NIP = company.NIP;
            }
            else{
                model.IsSetCompany = false;
            }
            return company;
        }

        public void UpdateCompany(CompanyViewModel model, string userId)
        {            
            Company company = (from c in context.Company join u in context.UserInCompany on c.CompanyID equals u.CompanyId where u.UserId.Equals(userId) select c).FirstOrDefault();
            if (company != null && company.CompanyID != 0)
            {
                model.IsSetCompany = true;
            }
            else
            {
                model.IsSetCompany = false;
            }
                if (model.IsSetCompany)
            {
                company.City = model.City;
                company.CompanyName = model.CompanyName;
                company.FlatNumber = model.FlatNumber;
                company.HouseNumber = model.HouseNumber;
                company.NIP = model.NIP;
                company.Street = model.CompanyStreet;
                company.ZipCode = model.ZipCode;
                context.Entry(company).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                addCompany(model, ref company);
                UserInCompany uic = new UserInCompany();
                uic.CompanyId = company.CompanyID;
                uic.UserId = userId;
                context.Entry(uic).State = System.Data.Entity.EntityState.Added;
            }
            context.SaveChanges();
        }

        public void AddCar(CarViewModels model)
        {
            Cars car = context.Cars.Where(c => c.CarPlate.Equals(model.CarPlate)).FirstOrDefault();
            if (car != null && car.Id != 0)
            {
                car.Name = model.Name;
                car.Model = model.Model;
                car.CarPlate = model.CarPlate;
                car.KmAge = model.KmAge;
                car.CarStatusId = model.CarStatusId;
                context.Entry(car).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                car = new Cars();
                car.Name = model.Name;
                car.Model = model.Model;
                car.CarPlate = model.CarPlate;
                car.KmAge = model.KmAge;
                car.CarStatusId = model.CarStatusId;
                context.Entry(car).State = System.Data.Entity.EntityState.Added;
            }
            context.SaveChanges();
        }

        public CarViewModels GetCarById(int id)
        {
            Cars car = context.Cars.Where(c => c.Id == id).FirstOrDefault();
            CarViewModels retval = new CarViewModels();
            retval.CarPlate = car.CarPlate;
            retval.CarStatus = car.CarStatus;
            retval.CarStatusId = car.CarStatusId;
            retval.Id = id;
            retval.KmAge = car.KmAge;
            retval.Model = car.Model;
            retval.Name = car.Name;
            return retval;
        }

        public IEnumerable<CarViewModels> GetAllCars()
        {
            List<CarViewModels> retval = new List<CarViewModels>();
            var list = context.Cars.Include(d => d.CarStatus).ToList();
            foreach(var item in list)
            {
                CarViewModels cvm = new CarViewModels();
                cvm.CarPlate = item.CarPlate;
                cvm.CarStatus = item.CarStatus;
                cvm.CarStatusId = item.CarStatusId;
                cvm.Id = item.Id;
                cvm.KmAge = item.KmAge;
                cvm.Model = item.Model;
                cvm.Name = item.Name;
                retval.Add(cvm);
            }
            return retval;
        }

        private void addCompany(CompanyViewModel model, ref Company company)
        {
            company = new Company();
            company.City = model.City;
            company.CompanyName = model.CompanyName;
            company.FlatNumber = model.FlatNumber;
            company.HouseNumber = model.HouseNumber;
            company.NIP = model.NIP;
            company.Street = model.CompanyStreet;
            company.ZipCode = model.ZipCode;
            context.Entry(company).State = System.Data.Entity.EntityState.Added;
            context.SaveChanges();
        }
    }
}