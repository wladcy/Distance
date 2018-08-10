using Distance.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Distance.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(AccountMessageId? message)
        {
            ViewBag.StatusMessage =
                message == AccountMessageId.RegisterAccountSuccess ? "Konto zostało utworzone. Na maila dostałeś instrukcję pełnej aktywacji."
                : message == AccountMessageId.StartTravelSuccess ? "Rozpocząłeś nową podróż służbową"
                : message == AccountMessageId.StopTravelSuccess ? "Zakończyłeś podróż służbową" 
                : message == AccountMessageId.ConfirmMailSendSuccess? "Mail z linkiem aktywacyjnym został wysłany": "";
            CurrentUserInTravelViewModels cuitvm = new CurrentUserInTravelViewModels();
            if (Request.IsAuthenticated)
            {
                DatabaseControler dc = new DatabaseControler();
                var userName = User.Identity.Name;
                ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = userManager.FindByName(userName);
                int carId = dc.HasCarInTravel(user.Id);
                cuitvm.CarId = carId;
                if (carId != 0)
                {
                    cuitvm.HasCarInTravel = true;
                }
            }
            else
            {
                cuitvm.HasCarInTravel = false;
            }
            return View(cuitvm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

    public enum AccountMessageId
    {
        RegisterAccountSuccess,
        StartTravelSuccess,
        StopTravelSuccess,
        ConfirmMailSendSuccess
    }
}