using PersonalFinancesManager.Models;
using PersonalFinancesManager.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalFinancesManager.Repositories
{
    public class Categories : ICategories
    {
        MainContext Context;

        public Categories()
        {
            Context = new MainContext();
        }

        public IEnumerable<ExpenseCategory> GetAll()
        {
            return Context.ExpenseCategories.AsEnumerable();
        }

        public ExpenseCategory Get(int id)
        {
            return Context.ExpenseCategories.FirstOrDefault(x => x.Id.Equals(id));
        }

        public void Create(ExpenseCategory item)
        {
            item = Context.ExpenseCategories.Add(item);
            Context.SaveChanges();
        }

        public void Update(int id, ExpenseCategory item)
        {
            var expenseCategory = Context.ExpenseCategories.FirstOrDefault(x => x.Id.Equals(id));
            
            if (expenseCategory == null)
            {
                throw new InvalidOperationException();
            }

            expenseCategory.Name = item.Name;
            expenseCategory.Description = item.Description;
            
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            ExpenseCategory expenseCategory = Context.ExpenseCategories.FirstOrDefault(x => x.Id.Equals(id));
            
            if (expenseCategory == null)
            {
                throw new InvalidOperationException();
            }

            Context.ExpenseCategories.Remove(expenseCategory);
            
            Context.SaveChanges();
        }
    }
}