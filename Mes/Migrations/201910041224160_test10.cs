namespace Mes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Assembly", "WorkplaceId", "dbo.Workplace");
            DropIndex("dbo.Assembly", new[] { "WorkplaceId" });
            AddColumn("dbo.WorkOrder", "WorkplaceId", c => c.Int());
            CreateIndex("dbo.WorkOrder", "WorkplaceId");
            AddForeignKey("dbo.WorkOrder", "WorkplaceId", "dbo.Workplace", "Id");
            DropColumn("dbo.Assembly", "WorkplaceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Assembly", "WorkplaceId", c => c.Int());
            DropForeignKey("dbo.WorkOrder", "WorkplaceId", "dbo.Workplace");
            DropIndex("dbo.WorkOrder", new[] { "WorkplaceId" });
            DropColumn("dbo.WorkOrder", "WorkplaceId");
            CreateIndex("dbo.Assembly", "WorkplaceId");
            AddForeignKey("dbo.Assembly", "WorkplaceId", "dbo.Workplace", "Id");
        }
    }
}
