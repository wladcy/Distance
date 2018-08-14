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
    public class TravelsController : Controller
    {
        public ActionResult StartTravel(string id)
        {
            TravelViewModels tvm = new TravelViewModels();
            tvm.Button = "Start";
            tvm.Title = "Rozpocznij podróż";
            int Id = 0;
            DatabaseControler dc = new DatabaseControler();
            if (!int.TryParse(id, out Id) || dc.IsInTravel(Id))
            {
                return RedirectToAction("Index", "Home");
            }
            tvm.CarId = Id;
            tvm.StopKm = "0";
            tvm.StartTravel = true;
            return View("TravelsForm", tvm);
        }

        [HttpPost]
        public ActionResult UpdateTravel(TravelViewModels model)
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
            if (model.StartTravel)
            {
                return RedirectToAction("Index", "Home", new { Message = AccountMessageId.StartTravelSuccess });
            }
            else
            {
                return RedirectToAction("Index", "Home", new { Message = AccountMessageId.StopTravelSuccess });
            }
        }

        public ActionResult StopTravel(string id)
        {
            DatabaseControler dc = new DatabaseControler();
            var userName = User.Identity.Name;
            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.FindByName(userName);
            int Id = 0;
            if (!int.TryParse(id, out Id))
            {
                return RedirectToAction("Index", "Home");
            }
            TravelViewModels tvm = dc.GetCurrentTravel(user, Id);
            tvm.Button = "Stop";
            tvm.Title = "Zakończ podróż";
            tvm.CarId = Id;
            tvm.StopKm = string.Empty;
            return View("TravelsForm", tvm);
        }

        public ActionResult Report(string id)
        {
            DatabaseControler dc = new DatabaseControler();
            var userName = User.Identity.Name;
            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.FindByName(userName);
            int Id = 0;
            if (!int.TryParse(id, out Id))
            {
                return RedirectToAction("Index", "Home");
            }
            SelectDateViewModel sdvm = dc.GetSelectDateModelByCarId(Id);
            return View("SelectDate", sdvm);
        }

        [HttpPost]
        public ActionResult Report(SelectDateViewModel model)
        {
            DatabaseControler dc = new DatabaseControler();
            SelectDateViewModel selectModel = dc.GetSelectDateModelByCarId(model.CarId);
            selectModel.MonthId = model.MonthId;
            selectModel.YearId = model.YearId;
            if (!ModelState.IsValid)
            {                
                return View("SelectDate", selectModel);
            }
            PdfController pc = new PdfController();
            return new FileStreamResult(pc.CreateDistanceReportByCarId(model.CarId,int.Parse(selectModel.Mounth.ToList()[model.MonthId].Value),int.Parse(selectModel.Year.ToList()[model.YearId].Value)), "application/pdf");
        }
    }
}