namespace PersonalFinancesManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class syncAzure : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Recurrent = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Parcels = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Paid = c.Boolean(nullable: false),
                        MethodOfPayment_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MethodOfPayments", t => t.MethodOfPayment_Id)
                .Index(t => t.MethodOfPayment_Id);
            
            CreateTable(
                "dbo.ExpenseCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Expense_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Expenses", t => t.Expense_Id)
                .Index(t => t.Expense_Id);
            
            CreateTable(
                "dbo.MethodOfPayments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ExpenseCategories", new[] { "Expense_Id" });
            DropIndex("dbo.Expenses", new[] { "MethodOfPayment_Id" });
            DropForeignKey("dbo.ExpenseCategories", "Expense_Id", "dbo.Expenses");
            DropForeignKey("dbo.Expenses", "MethodOfPayment_Id", "dbo.MethodOfPayments");
            DropTable("dbo.MethodOfPayments");
            DropTable("dbo.ExpenseCategories");
            DropTable("dbo.Expenses");
        }
    }
}
