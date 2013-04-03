using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalFinancesManager.Models;

namespace PersonalFinancesManager.Controllers
{
    public class DashboardController : Controller
    {
        private MainContext db = new MainContext();
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
        // GET: /Dashboard/ExpensesByDate

        public JsonResult DashboardExpensesByDate()
        {
            var expenses = db.Expenses.Select(ex => new {Despesa = ex.Name, Mes = ex.Date, Valor = ex.Amount});
            return Json(expenses);
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

                return RedirectToAction("Index", collection["beginDate"]);
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
