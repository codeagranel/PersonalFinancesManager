using PersonalFinancesManager.Models;
using PersonalFinancesManager.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalFinancesManager.Repositories
{
    public class Expenses : IExpenses
    {
        MainContext Context;

        public Expenses()
        {
            Context = new MainContext();
        }

        public IEnumerable<Models.Expense> GetAll()
        {
            return Context.Expenses.AsEnumerable();
        }

        public Models.Expense Get(int id)
        {
            return Context.Expenses.FirstOrDefault(x => x.Id.Equals(id));
        }

        public void Create(Models.Expense item)
        {
            item = Context.Expenses.Add(item);
            Context.SaveChanges();
        }

        public void Update(int id, Models.Expense item)
        {
            var expense = Context.Expenses.FirstOrDefault(x => x.Id.Equals(id));
            
            if (expense == null)
            {
                throw new InvalidOperationException();
            }

            expense.Amount = item.Amount;
            expense.Categories = item.Categories;
            expense.Date = item.Date;
            expense.MethodOfPayment = item.MethodOfPayment;
            expense.Name = item.Name;
            expense.Recurrent = item.Recurrent;

            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            Expense expense = Context.Expenses.FirstOrDefault(x => x.Id.Equals(id));

            if (expense == null)
            {
                throw new InvalidOperationException();
            }

            Context.Expenses.Remove(expense);

            Context.SaveChanges();
        }
    }
}