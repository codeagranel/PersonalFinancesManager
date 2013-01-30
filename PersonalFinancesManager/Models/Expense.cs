using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalFinancesManager.Models
{
    public class Expense
    {
        public Expense()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Recurrent { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public ExpenseCategory Category { get; set; }
        public MethodOfPayment MethodOfPayment { get; set; }
    }
}