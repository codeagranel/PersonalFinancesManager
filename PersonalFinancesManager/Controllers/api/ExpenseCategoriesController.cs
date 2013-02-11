using Microsoft.Practices.Unity;
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
    public class ExpenseCategoriesController : ApiController, IApiController<ExpenseCategory>
    {
        //DI não funcionou com webApi. Ele tem que usar um construtor padrão
        //TODO: Procurar um workaround melhor
        ICategories Categories = new Categories();

        public IEnumerable<ExpenseCategory> GetAll()
        {
            return Categories.GetAll();
        }

        public ExpenseCategory Get(int id)
        {
            return Categories.Get(id);
        }

        public HttpResponseMessage Post(ExpenseCategory item)
        {
            Categories.Create(item);
            var response = Request.CreateResponse<ExpenseCategory>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void Put(int id, ExpenseCategory item)
        {
            try
            {
                Categories.Update(id, item);
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
                Categories.Delete(id);
            }
            catch (InvalidOperationException)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}
