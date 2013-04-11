using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PersonalFinancesManager.Models
{
    public class MainContext : DbContext
    {
        public MainContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<MethodOfPayment> MethodsOfPayment { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}