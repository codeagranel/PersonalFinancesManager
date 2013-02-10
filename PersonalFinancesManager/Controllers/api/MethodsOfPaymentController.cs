using PersonalFinancesManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PersonalFinancesManager.Controllers.Api
{
    public class MethodsOfPaymentController : ApiController
    {
        MainContext Context = new MainContext();

        public MethodsOfPaymentController()
        {
        }

        public IEnumerable<MethodOfPayment> GetAllExpenses()
        {
            return Context.MethodsOfPayment.AsEnumerable();
        }

        public MethodOfPayment GetExpense(int id)
        {
            return Context.MethodsOfPayment.FirstOrDefault(x => x.Id.Equals(id));
        }

        public HttpResponseMessage PostExpense(MethodOfPayment item)
        {
            item = Context.MethodsOfPayment.Add(item);
            Context.SaveChanges();
            var response = Request.CreateResponse<MethodOfPayment>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutExpense(int id, MethodOfPayment item)
        {
            var methodOfPayment = Context.MethodsOfPayment.FirstOrDefault(x => x.Id.Equals(id));
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            methodOfPayment.Name = item.Name;
            methodOfPayment.Description = item.Description;

            Context.SaveChanges();
        }

        public void DeleteExpense(int id)
        {
            MethodOfPayment item = Context.MethodsOfPayment.FirstOrDefault(x => x.Id.Equals(id));
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Context.MethodsOfPayment.Remove(item);
        }
    }
}
