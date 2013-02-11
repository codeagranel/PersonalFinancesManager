using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinancesManager.Controllers.api.Interfaces
{
    public interface IApiController<T> 
        where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        HttpResponseMessage Post(T item);
        void Put(int id, T item);
        void Delete(int id);
    }
}
