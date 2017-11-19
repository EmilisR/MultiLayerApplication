using GuiLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuiLayer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult About()
        {
            ViewBag.Message = "Visa informacija apie mus";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Mus rasite";

            return View();
        }
    }
}