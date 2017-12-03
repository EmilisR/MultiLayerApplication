using GuiLayer.Helpers;
using GuiLayer.Models;
using LoginBLService;
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
        public static bool LoggedIn = false;
        public static string Email = string.Empty;

        // POST: /Account/Login
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid && !LoggedIn)
            {
                var service = UnityConfig.Container.Resolve<LoginService>();
                if (!service.Login(model.Email, model.Password))
                    model.Error = "Neteisingas el. paštas ir/ar slaptažodis!";
                else
                {
                    LoggedIn = true;
                    Email = model.Email;
                    return RedirectToAction(nameof(ItemController.ItemList), "Item");
                }
            }

            return View(model);
        }

        public ActionResult Logoff()
        {
            if (LoggedIn)
            {
                LoggedIn = false;
                Email = string.Empty;
            }
            return RedirectToAction(nameof(ItemController.ItemList), "Item");
        }

        public ActionResult Register(RegisterViewModel model)
        {
            if (!LoggedIn && ModelState.IsValid)
            {
                var service = UnityConfig.Container.Resolve<LoginService>();
                var success = service.Register(new RegisterInfo()
                {
                    Email = model.Email,
                    Name = model.Name,
                    Password = model.Password,
                    Phone = model.Phone,
                    Surname = model.Surname
                });
                if (success)
                    return RedirectToAction(nameof(AccountController.Login), "Account");
                else
                {
                    return View(new RegisterViewModel()
                    {
                        Email = "",
                        Name = "",
                        Password = "",
                        Phone = "",
                        Surname = "",
                        Error = "Toks vartotojas jau egzistuoja!"
                    });
                }
            }
            
            else if (model.Email != null)
            {
                return View(new RegisterViewModel()
                {
                    Email = "",
                    Name = "",
                    Password = "",
                    Phone = "",
                    Surname = "",
                    Error = "Toks vartotojas jau egzistuoja!"
                });
            }
            else
            {
                return View(new RegisterViewModel()
                {
                    Email = "",
                    Name = "",
                    Password = "",
                    Phone = "",
                    Surname = ""
                });
            }
        }
    }
}