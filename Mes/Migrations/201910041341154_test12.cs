namespace Mes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test12 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.WorkOrders", new[] { "AssemblyId" });
            DropIndex("dbo.WorkOrders", new[] { "CustomerId" });
            DropIndex("dbo.WorkOrders", new[] { "WorkplaceId" });
            AlterColumn("dbo.WorkOrders", "AssemblyId", c => c.Int(nullable: false));
            AlterColumn("dbo.WorkOrders", "CustomerId", c => c.Int(nullable: false));
            AlterColumn("dbo.WorkOrders", "WorkplaceId", c => c.Int(nullable: false));
            CreateIndex("dbo.WorkOrders", "AssemblyId");
            CreateIndex("dbo.WorkOrders", "CustomerId");
            CreateIndex("dbo.WorkOrders", "WorkplaceId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.WorkOrders", new[] { "WorkplaceId" });
            DropIndex("dbo.WorkOrders", new[] { "CustomerId" });
            DropIndex("dbo.WorkOrders", new[] { "AssemblyId" });
            AlterColumn("dbo.WorkOrders", "WorkplaceId", c => c.Int());
            AlterColumn("dbo.WorkOrders", "CustomerId", c => c.Int());
            AlterColumn("dbo.WorkOrders", "AssemblyId", c => c.Int());
            CreateIndex("dbo.WorkOrders", "WorkplaceId");
            CreateIndex("dbo.WorkOrders", "CustomerId");
            CreateIndex("dbo.WorkOrders", "AssemblyId");
        }
    }
}
