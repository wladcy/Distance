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
                :message==AccountMessageId.StartTravelSuccess? "Rozpocząłeś nową podróż służbową" : "";
            return View();
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
        StartTravelSuccess
    }
}