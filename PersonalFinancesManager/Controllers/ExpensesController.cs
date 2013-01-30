using PersonalFinancesManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PersonalFinancesManager.Controllers
{
    public class ExpensesController : ApiController
    {
        MainContext Context = new MainContext();

        public ExpensesController()
        {
        }

        public IEnumerable<Expense> GetAllExpenses()
        {
            return Context.Expenses.AsEnumerable();
        }

        public Expense GetExpense(int id)
        {
            return Context.Expenses.FirstOrDefault(x => x.Id.Equals(id));
        }

        public IEnumerable<Expense> GetExpensesByCategory(string category)
        {
            return Context.Expenses.Where(x => string.Equals(x.Category.Name, category, StringComparison.OrdinalIgnoreCase));
        }

        public HttpResponseMessage PostExpense(Expense item)
        {
            item = Context.Expenses.Add(item);
            Context.SaveChanges();
            var response = Request.CreateResponse<Expense>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutExpense(int id, Expense item)
        {
            var expense = Context.Expenses.FirstOrDefault(x => x.Id.Equals(id));
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            expense.Amount = item.Amount;
            expense.Category = item.Category;
            expense.Date = item.Date;
            expense.MethodOfPayment = item.MethodOfPayment;
            expense.Name = item.Name;
            expense.Recurrent = item.Recurrent;

            Context.SaveChanges();
        }

        public void DeleteExpense(int id)
        {
            Expense item = Context.Expenses.FirstOrDefault(x => x.Id.Equals(id));
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Context.Expenses.Remove(item);
        }
    }
}
