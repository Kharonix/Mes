namespace Mes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test11 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Assembly", newName: "Assemblies");
            RenameTable(name: "dbo.Inventory", newName: "Inventories");
            RenameTable(name: "dbo.WorkOrder", newName: "WorkOrders");
            RenameTable(name: "dbo.Customer", newName: "Customers");
            RenameTable(name: "dbo.Workplace", newName: "Workplaces");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Workplaces", newName: "Workplace");
            RenameTable(name: "dbo.Customers", newName: "Customer");
            RenameTable(name: "dbo.WorkOrders", newName: "WorkOrder");
            RenameTable(name: "dbo.Inventories", newName: "Inventory");
            RenameTable(name: "dbo.Assemblies", newName: "Assembly");
        }
    }
}
