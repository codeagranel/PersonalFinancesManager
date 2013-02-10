using PersonalFinancesManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PersonalFinancesManager.Controllers.Api
{
    public class ExpenseCategoriesController : ApiController
    {
        MainContext Context = new MainContext();

        public ExpenseCategoriesController()
        {
        }

        public IEnumerable<ExpenseCategory> GetAllExpenses()
        {
            return Context.ExpenseCategories.AsEnumerable();
        }

        public ExpenseCategory GetExpense(int id)
        {
            return Context.ExpenseCategories.FirstOrDefault(x => x.Id.Equals(id));
        }

        public HttpResponseMessage PostExpense(ExpenseCategory item)
        {
            item = Context.ExpenseCategories.Add(item);
            Context.SaveChanges();
            var response = Request.CreateResponse<ExpenseCategory>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutExpense(int id, ExpenseCategory item)
        {
            var expenseCategory = Context.ExpenseCategories.FirstOrDefault(x => x.Id.Equals(id));
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            expenseCategory.Name = item.Name;
            expenseCategory.Description = item.Description;

            Context.SaveChanges();
        }

        public void DeleteExpense(int id)
        {
            ExpenseCategory item = Context.ExpenseCategories.FirstOrDefault(x => x.Id.Equals(id));
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Context.ExpenseCategories.Remove(item);
        }
    }
}
