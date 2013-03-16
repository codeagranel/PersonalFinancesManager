using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalFinancesManager.Models;

namespace PersonalFinancesManager.Controllers
{
    public class CategoriesController : Controller
    {
        private MainContext db = new MainContext();

        //
        // GET: /Categories/

        [Authorize()]
        public ActionResult Index()
        {
            return View(db.ExpenseCategories.ToList());
        }

        //
        // GET: /Categories/Details/5

        public ActionResult Details(int id = 0)
        {
            ExpenseCategory expensecategory = db.ExpenseCategories.Find(id);
            if (expensecategory == null)
            {
                return HttpNotFound();
            }
            return View(expensecategory);
        }

        //
        // GET: /Categories/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Categories/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExpenseCategory expensecategory)
        {
            if (ModelState.IsValid)
            {
                db.ExpenseCategories.Add(expensecategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(expensecategory);
        }

        //
        // GET: /Categories/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ExpenseCategory expensecategory = db.ExpenseCategories.Find(id);
            if (expensecategory == null)
            {
                return HttpNotFound();
            }
            return View(expensecategory);
        }

        //
        // POST: /Categories/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExpenseCategory expensecategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expensecategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expensecategory);
        }

        //
        // GET: /Categories/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ExpenseCategory expensecategory = db.ExpenseCategories.Find(id);
            if (expensecategory == null)
            {
                return HttpNotFound();
            }
            return View(expensecategory);
        }

        //
        // POST: /Categories/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExpenseCategory expensecategory = db.ExpenseCategories.Find(id);
            db.ExpenseCategories.Remove(expensecategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}