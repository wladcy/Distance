using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Distance.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Distance.Controllers
{
    [Authorize]
    public class CarsController : Controller
    {
        private ApplicationDbContext _context;

        public CarsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //dodawanie kierowcy z danych pobranych z widoku Drivers/New
        [HttpPost]
        public ActionResult Create(DriverViewModels driver)
        {
            _context.Drivers.Add(driver);
            _context.SaveChanges();

            return RedirectToAction("Index", "Drivers");
        }


        public ActionResult New()
        {
            if (!IsAdministrator())
            {
                return RedirectToAction("Index", "Cars");
            }
            var carStatuses = _context.CarStatuses.ToList();

            var viewModel = new CarViewModels
            {
                CarStatus = carStatuses
            };

            return View("CarForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            if (!IsAdministrator())
            {
                return RedirectToAction("Index", "Cars");
            }
            DatabaseControler dc = new DatabaseControler();
            var car = dc.GetCarById(id);

            if (car == null)
                return HttpNotFound();

            car.CarStatus = _context.CarStatuses.ToList();            

            return View("CarForm", car);
        } 
   

        public ActionResult Index()
        {
            CarsViewModel model = new CarsViewModel();
            model.IsAdministrator = IsAdministrator();
            DatabaseControler dc = new DatabaseControler();
            var userName = User.Identity.Name;
            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.FindByName(userName);
            model.IsSetCompany = dc.IsSetCompany(user.Id);
            model.CarList = dc.GetAllCars(user);
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var car = _context.Cars.Include(d => d.CarStatus).SingleOrDefault(d => d.Id == id);

            return View(car);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CarViewModels car)
        {
            if (!ModelState.IsValid)
            {
                car.CarStatus = _context.CarStatuses.ToList();
                return View("CarForm", car);
            }

            DatabaseControler dc = new DatabaseControler();
            var userName = User.Identity.Name;
            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.FindByName(userName);
            dc.AddCar(car, user);

            return RedirectToAction("Index", "Cars");
        }

        public bool IsAdministrator()
        {
            bool retval = false;
            var userName = User.Identity.Name;
            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.FindByName(userName);
            if (userManager.GetRoles(user.Id).Contains("ADMINISTRATOR"))
            {
                retval = true;
            }
            return retval;
        }
    }
}