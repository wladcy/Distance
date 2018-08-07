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
    [Authorize]
    public class TravelsController: Controller
    {
        public ActionResult StartTravel(string id)
        {
            TravelViewModels tvm = new TravelViewModels();
            tvm.Button = "Start";
            tvm.Title = "Rozpocznij podróż";
            int Id = 0;
            if(!int.TryParse(id,out Id))
            {
                return RedirectToAction("Index", "Home");
            }
            tvm.CarId = Id;
            tvm.StopKm = "0";
            return View("TravelsForm",tvm);
        }

        [HttpPost]
        public ActionResult StartTravel(TravelViewModels model)
        {
            if (!ModelState.IsValid)
            {
                return View("TravelsForm", model);
            }
            DatabaseControler dc = new DatabaseControler();
            var userName = User.Identity.Name;
            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.FindByName(userName);
            dc.UpdateTravel(model, user);
            return RedirectToAction("Index", "Home", new { Message = AccountMessageId.StartTravelSuccess });
        }

        public ActionResult StopTravel(string id)
        {
            TravelViewModels tvm = new TravelViewModels();
            tvm.Button = "Stop";
            tvm.Title = "Zakończ podróż";
            int Id = 0;
            if (!int.TryParse(id, out Id))
            {
                return RedirectToAction("Index", "Home");
            }
            tvm.CarId = Id;
            return View("TravelsForm", tvm);
        }
    }
}