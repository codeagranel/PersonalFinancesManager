using PersonalFinancesManager.Models;
using PersonalFinancesManager.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinancesManager.Repositories
{
    public class MethodsOfPayment : IMethodsOfPayment
    {
        MainContext Context;

        public MethodsOfPayment()
        {
            Context = new MainContext();
        }

        public IEnumerable<MethodOfPayment> GetAll()
        {
            return Context.MethodsOfPayment.AsEnumerable();
        }

        public MethodOfPayment Get(int id)
        {
            return Context.MethodsOfPayment.FirstOrDefault(x => x.Id.Equals(id));
        }

        public void Create(MethodOfPayment item)
        {
            item = Context.MethodsOfPayment.Add(item);
            Context.SaveChanges();
        }

        public void Update(int id, MethodOfPayment item)
        {
            var method = Context.MethodsOfPayment.FirstOrDefault(x => x.Id.Equals(id));

            if (method == null)
            {
                throw new InvalidOperationException();
            }

            method.Name = item.Name;
            method.Description = item.Description;

            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            MethodOfPayment method = Context.MethodsOfPayment.FirstOrDefault(x => x.Id.Equals(id));

            if (method == null)
            {
                throw new InvalidOperationException();
            }

            Context.MethodsOfPayment.Remove(method);

            Context.SaveChanges();
        }
    }
}
