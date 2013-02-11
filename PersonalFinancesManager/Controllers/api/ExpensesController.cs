using PersonalFinancesManager.Controllers.api.Interfaces;
using PersonalFinancesManager.Models;
using PersonalFinancesManager.Repositories;
using PersonalFinancesManager.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PersonalFinancesManager.Controllers.Api
{
    public class ExpensesController : ApiController, IApiController<Expense>
    {
        //DI não funcionou com webApi. Ele tem que usar um construtor padrão
        //TODO: Procurar um workaround melhor
        IExpenses Expenses = new Expenses();

        public IEnumerable<Expense> GetAll()
        {
            return Expenses.GetAll();
        }

        public Expense Get(int id)
        {
            return Expenses.Get(id); ;
        }

        public HttpResponseMessage Post(Expense item)
        {
            Expenses.Create(item);
            var response = Request.CreateResponse<Expense>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void Put(int id, Expense item)
        {
            try
            {
                Expenses.Update(id, item);
            }
            catch (InvalidOperationException)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void Delete(int id)
        {
            try
            {
                Expenses.Delete(id);
            }
            catch (InvalidOperationException)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}
