using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalFinancesManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modifique este modelo para iniciar rapidamente seu aplicativo ASP.NET MVC.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "A página de descrição do aplicativo.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Sua página de contato.";

            return View();
        }
    }
}
