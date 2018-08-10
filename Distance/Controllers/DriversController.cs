using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Distance.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Distance.App_Start;
using System.ComponentModel.DataAnnotations;

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
        public ActionResult Save(DriverViewModels model)
        {
            if (!ModelState.IsValid)
            {
                return View("DriverForm", model);
            }
            else if (!IsAdministrator())
            {
                RedirectToAction("Index", "Home");
            }

            DatabaseControler dc = new DatabaseControler();
            IdentityResult result = IdentityResult.Success;
            ApplicationUser user = new ApplicationUser();
            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            if (string.IsNullOrEmpty(model.Id))
            {
                user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                result = userManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    user.City = model.City;
                    user.FirstName = model.FirstName;
                    user.FlatNumber = model.FlatNumber;
                    user.HouseNumber = model.HouseNumber;
                    user.LastName = model.LastName;
                    user.Street = model.Street;
                    user.ZipCode = model.ZipCode;
                    user.CreateTime = DateTime.Now;
                    user.ModyfiTime = DateTime.Now;
                    user.EmailConfirmed = true;
                    user.PhoneNumberConfirmed = true;
                    user.PhoneNumber = "+48" + model.Number;
                    user.TwoFactorEnabled = true;
                    var currentUser = userManager.FindByName(user.UserName);
                    var role = userManager.AddToRole(currentUser.Id, "Kierowca".ToUpper());
                }
                AddErrors(result);
            }
            else
            {
                user = dc.GetUserById(model.Id);
                user.City = model.City;
                user.FirstName = model.FirstName;
                user.FlatNumber = model.FlatNumber;
                user.HouseNumber = model.HouseNumber;
                user.LastName = model.LastName;
                user.Street = model.Street;
                user.ZipCode = model.ZipCode;
                user.CreateTime = DateTime.Now;
                user.ModyfiTime = DateTime.Now;
                user.Email = model.Email;
                user.ModyfiTime = DateTime.Now;
                user.PhoneNumber = model.Number;
            }

            if (result.Succeeded)
                dc.UpdateUserData(user, User.Identity.GetUserId());
            return RedirectToAction("Index", "Drivers");
        }

        // GET: Drivers cała lista kierowców
        public ActionResult Index()
        {
            DatabaseControler dc = new DatabaseControler();
            var userName = User.Identity.Name;
            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.FindByName(userName);
            if (!IsAdministrator(user.Id))
            {
                RedirectToAction("Index", "Home");
            }
            var drivers = dc.GetAllUsers(user);
            DriversViewModels model = new DriversViewModels();
            model.Drivers = drivers;
            model.IsSetCompany = dc.IsSetCompany(user.Id);
            return View(model);
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
            viewModel.City = driver.City;
            viewModel.Email = driver.Email;
            viewModel.FirstName = driver.FirstName;
            viewModel.LastName = driver.LastName;
            viewModel.Number = driver.PhoneNumber;
            viewModel.Street = driver.Street;
            viewModel.ZipCode = driver.ZipCode;
            viewModel.FlatNumber = driver.FlatNumber;
            viewModel.HouseNumber = driver.HouseNumber;
            viewModel.Id = driver.Id;
            viewModel.IsEditMode = true;
            string password = passwordGenerator();
            viewModel.Password = password;
            viewModel.ConfirmPassword = password;

            return View("DriverForm", viewModel);
        }

        public static string GetUserNameById(string Id)
        {
            DatabaseControler dc = new DatabaseControler();
            ApplicationUser user = dc.GetUserById(Id);
            return user.FirstName + " " + user.LastName;
        }

        public static bool IsAdministrator(string Id)
        {
            bool retval = false;
            DatabaseControler dc = new DatabaseControler();
            ApplicationUser user = dc.GetUserById(Id);
            if (dc.GetUserRoles(user).Contains("ADMINISTRATOR"))
            {
                retval = true;
            }
            return retval;
        }

        public bool IsAdministrator()
        {
            bool retval = false;
            DatabaseControler dc = new DatabaseControler();
            var userId = User.Identity.GetUserId();
            ApplicationUser user = dc.GetUserById(userId);
            if (dc.GetUserRoles(user).Contains("ADMINISTRATOR"))
            {
                retval = true;
            }
            return retval;
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private string passwordGenerator()
        {
            //TODO Hasło powinno zawierać przynajmniej jeden znak niealfanumeryczny. Hasło powinno zawierać przynajmniej jedną cyfrę.
            //generated password doesn't meeting the system valitation requirements
            const string LOWERCASE_CHARACTERS = "abcdefghijklmnopqrstuvwxyz";
            const string UPPERCASE_CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string NUMERIC_CHARACTERS = "0123456789";
            const string SPECIAL_CHARACTERS = @"!#$%&*@\,.^()-=/+{}[];:'|?><";
            string characterSet = "";

            if (PasswordIdentityConfig.REQUIRELOWERCASE)
            {
                characterSet += LOWERCASE_CHARACTERS;
            }

            if (PasswordIdentityConfig.REQUIREUPPERCASE)
            {
                characterSet += UPPERCASE_CHARACTERS;
            }

            if (PasswordIdentityConfig.REQUIREDIGIT)
            {
                characterSet += NUMERIC_CHARACTERS;
            }

            if (PasswordIdentityConfig.REQUIRENONLETTERORDIGIT)
            {
                characterSet += SPECIAL_CHARACTERS;
            }

            string password = string.Empty;
            int characterSetLength = characterSet.Length;

            Random random = new Random();
            while (password.Length != PasswordIdentityConfig.REQUIREDLENGTH)
            {
                password = string.Empty;
                while (!isPasswordCorrect(password) || password.Length < 6)
                {
                    char c = characterSet[random.Next(characterSetLength - 1)];
                    password += c;
                    characterSet = characterSet.Replace(c.ToString(), "");
                    characterSetLength = characterSet.Length;
                }
                characterSet = String.Concat(password.OrderBy(c=>c));
                characterSetLength = password.Length;
            }
            return password;
        }

        private bool isPasswordCorrect(string password)
        {
            bool retval = false;
            IPasswordViewModels pvm = new DriverViewModels();
            pvm.Password = password;
            ValidationContext vc = new ValidationContext(pvm);
            Validators.PasswordValidator pv = new Validators.PasswordValidator();
            retval = pv.IsValid(vc) == null;
            return retval;
        }
    }
}