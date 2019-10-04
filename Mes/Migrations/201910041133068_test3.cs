namespace Mes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Assembly", "WorkplaceId", "dbo.Workplace");
            DropIndex("dbo.Assembly", new[] { "WorkplaceId" });
            DropIndex("dbo.Assembly", new[] { "CustomerId" });
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
                        Count = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DoneCount = c.Decimal(precision: 18, scale: 2),
                        WorkOrderStatus = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Assembly", t => t.AssemblyId)
                .Index(t => t.AssemblyId)
                .Index(t => t.CustomerId);
            
            AlterColumn("dbo.Assembly", "WorkplaceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Assembly", "WorkplaceId");
            AddForeignKey("dbo.Assembly", "WorkplaceId", "dbo.Workplace", "Id", cascadeDelete: true);
            DropColumn("dbo.Assembly", "Number");
            DropColumn("dbo.Assembly", "StartDate");
            DropColumn("dbo.Assembly", "EndDate");
            DropColumn("dbo.Assembly", "CustomerId");
            DropColumn("dbo.Assembly", "Count");
            DropColumn("dbo.Assembly", "DoneCount");
            DropColumn("dbo.Assembly", "WorkOrderStatus");
            DropColumn("dbo.Assembly", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Assembly", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Assembly", "WorkOrderStatus", c => c.Byte());
            AddColumn("dbo.Assembly", "DoneCount", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Assembly", "Count", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Assembly", "CustomerId", c => c.Int());
            AddColumn("dbo.Assembly", "EndDate", c => c.DateTime());
            AddColumn("dbo.Assembly", "StartDate", c => c.DateTime());
            AddColumn("dbo.Assembly", "Number", c => c.Int());
            DropForeignKey("dbo.Assembly", "WorkplaceId", "dbo.Workplace");
            DropForeignKey("dbo.WorkOrder", "AssemblyId", "dbo.Assembly");
            DropIndex("dbo.WorkOrder", new[] { "CustomerId" });
            DropIndex("dbo.WorkOrder", new[] { "AssemblyId" });
            DropIndex("dbo.Assembly", new[] { "WorkplaceId" });
            AlterColumn("dbo.Assembly", "WorkplaceId", c => c.Int());
            DropTable("dbo.WorkOrder");
            CreateIndex("dbo.Assembly", "CustomerId");
            CreateIndex("dbo.Assembly", "WorkplaceId");
            AddForeignKey("dbo.Assembly", "WorkplaceId", "dbo.Workplace", "Id");
        }
    }
}
