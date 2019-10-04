namespace Mes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkOrder", "AssemblyId", "dbo.Assembly");
            DropIndex("dbo.WorkOrder", new[] { "AssemblyId" });
            DropIndex("dbo.WorkOrder", new[] { "CustomerId" });
            AddColumn("dbo.Assembly", "Number", c => c.Int());
            AddColumn("dbo.Assembly", "StartDate", c => c.DateTime());
            AddColumn("dbo.Assembly", "EndDate", c => c.DateTime());
            AddColumn("dbo.Assembly", "CustomerId", c => c.Int());
            AddColumn("dbo.Assembly", "Count", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Assembly", "DoneCount", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Assembly", "WorkOrderStatus", c => c.Byte());
            AddColumn("dbo.Assembly", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Assembly", "CustomerId");
            DropTable("dbo.WorkOrder");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            DropIndex("dbo.Assembly", new[] { "CustomerId" });
            DropColumn("dbo.Assembly", "Discriminator");
            DropColumn("dbo.Assembly", "WorkOrderStatus");
            DropColumn("dbo.Assembly", "DoneCount");
            DropColumn("dbo.Assembly", "Count");
            DropColumn("dbo.Assembly", "CustomerId");
            DropColumn("dbo.Assembly", "EndDate");
            DropColumn("dbo.Assembly", "StartDate");
            DropColumn("dbo.Assembly", "Number");
            CreateIndex("dbo.WorkOrder", "CustomerId");
            CreateIndex("dbo.WorkOrder", "AssemblyId");
            AddForeignKey("dbo.WorkOrder", "AssemblyId", "dbo.Assembly", "Id");
        }
    }
}
