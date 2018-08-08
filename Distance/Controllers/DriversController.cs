using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Distance.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace Distance.Controllers
{
    [Authorize]
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
            var viewModel = new DriverViewModels();
            

            return View("DriverForm", viewModel);
        }

        //Dodawanie kierowcy z formularza do bazy danych
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ApplicationUser driver)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new DriverViewModels();                

                return View("DriverForm", viewModel);
            }

            //TODO ADD USER

            //if (driver.Id == 0)
            //    _context.Users.Add(driver);
            //else
            //{
            //    var driverInDb = _context.Drivers.Single(d => d.Id == driver.Id);

            //    driverInDb.Name = driver.Name;
            //    driverInDb.Surname = driver.Surname;
            //    driverInDb.Birthdate = driver.Birthdate;
            //    driverInDb.IsPremiumAccount = driver.IsPremiumAccount;
            //    driverInDb.AccountTypeId = driver.AccountTypeId;
            //}

            //_context.SaveChanges();

            return RedirectToAction("Index", "Drivers");
        }

        // GET: Drivers cała lista kierowców
        public ActionResult Index()
        {
            DatabaseControler dc = new DatabaseControler();
            var userName = User.Identity.Name;
            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.FindByName(userName);
            var drivers = dc.GetAllUsers(user);
            
            return View(drivers);
        }

        //szczegóły kierowcow
        public ActionResult Details(int id)
        {
            var driver = _context.Users.SingleOrDefault(d => d.Id.Equals(id));

            if (driver == null) //jesli nie ma kierowcy o danym id wywal 404
                return HttpNotFound();

            return View(driver);
        }
      
        //Edytowanie kierowcy
        public ActionResult Edit(string id)
        {
            var driver = _context.Users.SingleOrDefault(d => d.Id.Equals(id));

            if (driver == null)
                return HttpNotFound();

            var viewModel = new DriverViewModels();
            
            return View("DriverForm", viewModel);
        }

        public static string GetUserNameById(string Id)
        {
            DatabaseControler dc = new DatabaseControler();
            ApplicationUser user = dc.GetUserById(Id);
            return user.FirstName + " " + user.LastName;
        }
    }
}