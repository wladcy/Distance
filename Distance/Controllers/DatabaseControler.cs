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
            List<DicCountries> list = context.DicCountries.OrderBy(c => c.CountryCodeA3).ToList();
            List<DirectPhones> retval = new List<DirectPhones>();
            foreach (DicCountries dc in list)
            {
                DirectPhones dp = new DirectPhones();
                dp.Id = dc.CountryID;
                dp.Name = dc.CountryCodeA3 + " +" + dc.CountryDirectPhoneNumber;
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
                model.Street = company.Street;
                model.FlatNumber = company.FlatNumber;
                model.HouseNumber = company.HouseNumber;
                model.IsSetCompany = true;
                model.ZipCode = company.ZipCode;
                model.NIP = company.NIP;
            }
            else
            {
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
                company.Street = model.Street;
                company.ZipCode = model.ZipCode;
                company.CreateTime = DateTime.Now;
                company.ModyfiTime = DateTime.Now;
                context.Entry(company).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                addCompany(model, ref company);
                UserInCompany uic = new UserInCompany();
                uic.CompanyId = company.CompanyID;
                uic.UserId = userId;
                uic.CreateTime = DateTime.Now;
                uic.ModyfiTime = DateTime.Now;
                context.Entry(uic).State = System.Data.Entity.EntityState.Added;
            }
            context.SaveChanges();
        }

        public void AddCar(CarViewModels model, ApplicationUser user)
        {
            Cars car = context.Cars.Where(c => c.CarPlate.Equals(model.CarPlate)).FirstOrDefault();
            if (car != null && car.Id != 0)
            {
                car.Name = model.Name;
                car.Model = model.Model;
                car.CarPlate = model.CarPlate;
                car.KmAge = model.KmAge;
                car.EngineCapacity = model.EngineCapacity;
                car.CarStatusId = model.CarStatusId;
                car.CreateTime = DateTime.Now;
                car.ModyfiTime = DateTime.Now;
                context.Entry(car).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                car = new Cars();
                car.Name = model.Name;
                car.Model = model.Model;
                car.CarPlate = model.CarPlate;
                car.KmAge = model.KmAge;
                car.EngineCapacity = model.EngineCapacity;
                car.CarStatusId = model.CarStatusId;
                car.CompanyId = getCompanyIdByUser(user);
                car.CreateTime = DateTime.Now;
                car.ModyfiTime = DateTime.Now;
                context.Entry(car).State = System.Data.Entity.EntityState.Added;
            }
            context.SaveChanges();
        }

        public CarViewModels GetCarById(int id)
        {
            Cars car = context.Cars.Where(c => c.Id == id).FirstOrDefault();
            CarViewModels retval = new CarViewModels();
            retval.CarPlate = car.CarPlate;
            List<CarStatuses> status = new List<CarStatuses>();
            status.Add(car.CarStatus);
            retval.CarStatus = status;
            retval.CarStatusId = car.CarStatusId;
            retval.Id = id;
            retval.KmAge = car.KmAge;
            retval.EngineCapacity = car.EngineCapacity;
            retval.Model = car.Model;
            retval.Name = car.Name;
            return retval;
        }

        public IEnumerable<CarViewModels> GetAllCars(ApplicationUser user)
        {
            List<CarViewModels> retval = new List<CarViewModels>();
            int companyId = getCompanyIdByUser(user);
            var list = context.Cars.Include(d => d.CarStatus).Where(d=>d.CompanyId==companyId).ToList();
            foreach (var item in list)
            {
                CarViewModels cvm = new CarViewModels();
                cvm.CarPlate = item.CarPlate;
                List<CarStatuses> status = new List<CarStatuses>();
                status.Add(item.CarStatus);
                cvm.CarStatus = status;
                cvm.CarStatusId = item.CarStatusId;
                cvm.Id = item.Id;
                cvm.KmAge = item.KmAge;
                cvm.EngineCapacity = item.EngineCapacity;
                cvm.Model = item.Model;
                cvm.Name = item.Name;
                retval.Add(cvm);
            }
            return retval;
        }

        public bool IsSetCompany(string userId)
        {
            bool retval = false;
            Company company = (from c in context.Company join u in context.UserInCompany on c.CompanyID equals u.CompanyId where u.UserId.Equals(userId) select c).FirstOrDefault();
            if (company != null && company.CompanyID != 0)
            {
                retval = true;
            }

            return retval;
        }

        public void UpdateUserData(ApplicationUser user)
        {
            context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();
        }

        private int getCompanyIdByUser(ApplicationUser user)
        {
            UserInCompany company = context.UserInCompany.Where(u => u.User.Id.Equals(user.Id)).FirstOrDefault();
            return company.CompanyId;
        }

        private void addCompany(CompanyViewModel model, ref Company company)
        {
            company = new Company();
            company.City = model.City;
            company.CompanyName = model.CompanyName;
            company.FlatNumber = model.FlatNumber;
            company.HouseNumber = model.HouseNumber;
            company.NIP = model.NIP;
            company.Street = model.Street;
            company.ZipCode = model.ZipCode;
            company.CreateTime = DateTime.Now;
            company.ModyfiTime = DateTime.Now;
            context.Entry(company).State = System.Data.Entity.EntityState.Added;
            context.SaveChanges();
        }
    }
}