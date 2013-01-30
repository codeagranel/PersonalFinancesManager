using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalFinancesManager.Models
{
    public class ExpenseCategory
    {
        public ExpenseCategory()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}