using GuiLayer.Helpers;
using GuiLayer.Models;
using Login.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace GuiLayer.Controllers
{
    public class AccountController : Controller
    {
        // POST: /Account/Login
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var service = UnityConfig.Container.Resolve<LoginService>();
                if (!service.Login(model.Email, model.Password))
                    model.Error = "Neteisingas el. paštas ir/ar slaptažodis!";
            }

            return View(model);
        }
    }
}