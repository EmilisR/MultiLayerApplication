using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuiLayer.Controllers
{
    public class BasketController : Controller
    {
        // GET: Basket
        public ActionResult Basket(BasketViewModel basketViewModel)
        {
            return View();
        }
    }
}