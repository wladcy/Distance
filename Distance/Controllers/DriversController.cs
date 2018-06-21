using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Distance.Models;
using System.Data.Entity;
using Distance.ViewModels;

namespace Distance.Controllers
{
    public class DriversController : Controller
    {
        private ApplicationDbContext _context;

        //dbcontext dla bazy danych
        public DriversController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //Dodanie nowego kierowcy
        public ActionResult New()
        {
            var accountTypes = _context.AccountTypes.ToList();
            var viewModel = new NewDriverViewModel
            {
                Driver = new Driver(),
                AccountTypes = accountTypes
            };

            return View("DriverForm", viewModel);
        }

        //Dodawanie kierowcy z formularza do bazy danych
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Driver driver)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new NewDriverViewModel
                {
                    Driver = driver,
                    AccountTypes = _context.AccountTypes.ToList()
                };

                return View("DriverForm", viewModel);
            }

            if (driver.Id == 0)
                _context.Drivers.Add(driver);
            else
            {
                var driverInDb = _context.Drivers.Single(d => d.Id == driver.Id);

                driverInDb.Name = driver.Name;
                driverInDb.Surname = driver.Surname;
                driverInDb.Birthdate = driver.Birthdate;
                driverInDb.IsPremiumAccount = driver.IsPremiumAccount;
                driverInDb.AccountTypeId = driver.AccountTypeId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Drivers");
        }

        // GET: Drivers cała lista kierowców
        public ActionResult Index()
        {
            var drivers = _context.Drivers.Include(d => d.AccountType).ToList(); 
            
            return View(drivers);
        }

        //szczegóły kierowcow
        public ActionResult Details(int id)
        {
            var driver = _context.Drivers.Include(d => d.AccountType).SingleOrDefault(d => d.Id == id);

            if (driver == null) //jesli nie ma kierowcy o danym id wywal 404
                return HttpNotFound();

            return View(driver);
        }
      
        //Edytowanie kierowcy
        public ActionResult Edit(int id)
        {
            var driver = _context.Drivers.SingleOrDefault(d => d.Id == id);

            if (driver == null)
                return HttpNotFound();

            var viewModel = new NewDriverViewModel
            {
                Driver = driver,
                AccountTypes = _context.AccountTypes.ToList()
            };
            return View("DriverForm", viewModel);
        }
    }
}