using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Distance.Models;
using Distance.ViewModels;
using System.Data.Entity;

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
            var carStatuses = _context.CarStatuses.ToList();

            var viewModel = new NewCarViewModel
            {
                CarStatuses = carStatuses
            };

            return View("CarForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            DatabaseControler dc = new DatabaseControler();
            var car = dc.GetCarById(id);

            if (car == null)
                return HttpNotFound();

            var viewModel = new NewCarViewModel(car)
            {
                CarStatuses = _context.CarStatuses.ToList()
            };

            return View("CarForm", viewModel);
        } 
   

        public ActionResult Index()
        {
            DatabaseControler dc = new DatabaseControler();
            return View(dc.GetAllCars());
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
                var viewModel = new NewCarViewModel(car)
                {
                    CarStatuses = _context.CarStatuses.ToList()
                };

                return View("CarForm", car);
            }

            DatabaseControler dc = new DatabaseControler();
            dc.AddCar(car);

            return RedirectToAction("Index", "Cars");
        }
    }
}