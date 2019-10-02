namespace Mes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInventoryNew : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inventory", "InventoryStatus", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inventory", "InventoryStatus");
        }
    }
}
