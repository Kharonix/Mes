namespace Mes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkOrder", "AssemblyId", "dbo.Assembly");
            DropForeignKey("dbo.WorkOrder", "CustomerId", "dbo.Customer");
            DropIndex("dbo.WorkOrder", new[] { "AssemblyId" });
            DropIndex("dbo.WorkOrder", new[] { "CustomerId" });
            AlterColumn("dbo.WorkOrder", "AssemblyId", c => c.Int());
            AlterColumn("dbo.WorkOrder", "CustomerId", c => c.Int());
            CreateIndex("dbo.WorkOrder", "AssemblyId");
            CreateIndex("dbo.WorkOrder", "CustomerId");
            AddForeignKey("dbo.WorkOrder", "AssemblyId", "dbo.Assembly", "Id");
            AddForeignKey("dbo.WorkOrder", "CustomerId", "dbo.Customer", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkOrder", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.WorkOrder", "AssemblyId", "dbo.Assembly");
            DropIndex("dbo.WorkOrder", new[] { "CustomerId" });
            DropIndex("dbo.WorkOrder", new[] { "AssemblyId" });
            AlterColumn("dbo.WorkOrder", "CustomerId", c => c.Int(nullable: false));
            AlterColumn("dbo.WorkOrder", "AssemblyId", c => c.Int(nullable: false));
            CreateIndex("dbo.WorkOrder", "CustomerId");
            CreateIndex("dbo.WorkOrder", "AssemblyId");
            AddForeignKey("dbo.WorkOrder", "CustomerId", "dbo.Customer", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WorkOrder", "AssemblyId", "dbo.Assembly", "Id", cascadeDelete: true);
        }
    }
}
