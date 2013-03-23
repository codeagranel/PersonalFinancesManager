using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalFinancesManager.Controllers
{
    public class DashboardController : Controller
    {
        //
        // GET: /Dashboard/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Dashboard/Details/5

        public ActionResult Details()
        {
            return View();
        }

        //
        // GET: /Dashboard/ExpensesByDate

        public ActionResult ExpensesByDate()
        {
            return View();
        }

        //
        // POST: /Dashboard/ExpensesByDate

        [HttpPost]
        public ActionResult ExpensesByDate(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                //Call to google chart's

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Dashboard/ExpensesByCategory

        public ActionResult ExpensesByCategory()
        {
            return View();
        }

        //
        // POST: /Dashboard/ExpensesByCategory

        [HttpPost]
        public ActionResult ExpensesByCategory(FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
