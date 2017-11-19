﻿using GuiLayer.Helpers;
using GuiLayer.Models;
using Login.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GuiLayer.Controllers
{
    public class AccountController : Controller
    {
        /*public ActionResult Login()
        {
            ViewBag.Message = "Prisijungimas";

            return View();
        }
        */
        // POST: /Account/Login
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var service = new LoginService();
                if (!service.Login(model.Email, model.Password))
                    model.Error = "Neteisingas el. paštas ir/ar slaptažodis!";
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
    }
}