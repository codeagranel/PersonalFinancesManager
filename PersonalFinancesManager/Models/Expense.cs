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
        public string Description { get; set; }

        public bool Recurrent { get; set; }
        public DateTime Date { get; set; }
        public int Parcels { get; set; }
        public decimal Amount { get; set; }
        public bool Paid { get; set; }
        public List<ExpenseCategory> Categories { get; set; }
        public MethodOfPayment MethodOfPayment { get; set; }
    }
}