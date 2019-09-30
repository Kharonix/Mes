namespace Mes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1234 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assembly",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssemblyId = c.Int(nullable: false),
                        Count = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Assembly", t => t.AssemblyId, cascadeDelete: true)
                .Index(t => t.AssemblyId);
            
            CreateTable(
                "dbo.WorkOrder",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        AssemblyId = c.Int(),
                        CustomerId = c.Int(),
                        WorkplaceId = c.Int(nullable: false),
                        Count = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DoneCount = c.Decimal(precision: 18, scale: 2),
                        WorkOrderStatus = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Assembly", t => t.AssemblyId)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .ForeignKey("dbo.Workplace", t => t.WorkplaceId, cascadeDelete: true)
                .Index(t => t.AssemblyId)
                .Index(t => t.CustomerId)
                .Index(t => t.WorkplaceId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Workplace",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkOrder", "WorkplaceId", "dbo.Workplace");
            DropForeignKey("dbo.WorkOrder", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.WorkOrder", "AssemblyId", "dbo.Assembly");
            DropForeignKey("dbo.Inventory", "AssemblyId", "dbo.Assembly");
            DropIndex("dbo.WorkOrder", new[] { "WorkplaceId" });
            DropIndex("dbo.WorkOrder", new[] { "CustomerId" });
            DropIndex("dbo.WorkOrder", new[] { "AssemblyId" });
            DropIndex("dbo.Inventory", new[] { "AssemblyId" });
            DropTable("dbo.Workplace");
            DropTable("dbo.Customer");
            DropTable("dbo.WorkOrder");
            DropTable("dbo.Inventory");
            DropTable("dbo.Assembly");
        }
    }
}
