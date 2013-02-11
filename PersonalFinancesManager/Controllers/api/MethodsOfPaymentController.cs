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
    public class MethodsOfPaymentController : ApiController, IApiController<MethodOfPayment>
    {
        //DI não funcionou com webApi. Ele tem que usar um construtor padrão
        //TODO: Procurar um workaround melhor
        IMethodsOfPayment MethodsOfPayment = new MethodsOfPayment();

        public IEnumerable<MethodOfPayment> GetAll()
        {
            return MethodsOfPayment.GetAll();
        }

        public MethodOfPayment Get(int id)
        {
            return MethodsOfPayment.Get(id);
        }

        public HttpResponseMessage Post(MethodOfPayment item)
        {
            MethodsOfPayment.Create(item);
            var response = Request.CreateResponse<MethodOfPayment>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void Put(int id, MethodOfPayment item)
        {
            try
            {
                MethodsOfPayment.Update(id, item);
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
                MethodsOfPayment.Delete(id);
            }
            catch (InvalidOperationException)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}
