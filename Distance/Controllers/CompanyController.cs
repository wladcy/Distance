﻿using Distance.Models;
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
    public class CompanyController:Controller
    {
        //GET: /Company/Index
        [HttpGet]
        public ActionResult Index(CompanytMessageId? message)
        {
            ViewBag.StatusMessage =
                message == CompanytMessageId.UpdateCompanySuccess ? "Dane firmy zostały zapisane w bazie." : "";
            var userName = User.Identity.Name;
            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.FindByName(userName);            
            CompanyViewModel cc = new CompanyViewModel();
            if (userManager.GetRoles(user.Id).Contains("ADMINISTRATOR"))
            {
                cc.IsAdministrator = true;
            }
            cc.IsAccountConfirmed = user.EmailConfirmed;
            DatabaseControler dc = new DatabaseControler();
            dc.GetCompany(ref cc, user.Id);
            return View(cc);
        }

        //GET: /Company/UpdateCompany
        [HttpGet]
        public ActionResult UpdateCompany()
        {
            var userName = User.Identity.Name;
            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.FindByName(userName);
            CompanyViewModel cc = new CompanyViewModel();
            DatabaseControler dc = new DatabaseControler();
            dc.GetCompany(ref cc, user.Id);
            return View(cc);
        }

        //POST: /Company/UpdateCompany
        [HttpPost]
        public ActionResult UpdateCompany(CompanyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var userName = User.Identity.Name;
            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.FindByName(userName);
            DatabaseControler dc = new DatabaseControler();
            dc.UpdateCompany(model, user.Id);
            return RedirectToAction("Index", "Company", new { Message = CompanytMessageId.UpdateCompanySuccess });
        }
    }

    public enum CompanytMessageId
    {
        UpdateCompanySuccess
    }
}