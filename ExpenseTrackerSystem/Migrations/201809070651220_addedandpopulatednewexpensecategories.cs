namespace ExpenseTrackerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedandpopulatednewexpensecategories : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[Categories] ([Name]) VALUES ('Food')");
            Sql("INSERT INTO [dbo].[Categories] ([Name]) VALUES ('Travel')");
            Sql("INSERT INTO [dbo].[Categories] ([Name]) VALUES ('Entertainment')");
            Sql("INSERT INTO [dbo].[Categories] ([Name]) VALUES ('Health')");
            Sql("INSERT INTO [dbo].[Categories] ([Name]) VALUES ('Electronics')");
            Sql("INSERT INTO [dbo].[Categories] ([Name]) VALUES ('Furniture')");
            Sql("INSERT INTO [dbo].[Categories] ([Name]) VALUES ('VehicleExpense')");
            Sql("INSERT INTO [dbo].[Categories] ([Name]) VALUES ('UtilityBills')");
            Sql("INSERT INTO [dbo].[Categories] ([Name]) VALUES ('Taxes')");
        }
        
        public override void Down()
        {
        }
    }
}
