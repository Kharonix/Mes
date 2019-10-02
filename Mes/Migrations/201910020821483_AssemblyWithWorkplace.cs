namespace Mes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssemblyWithWorkplace : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkOrder", "WorkplaceId", "dbo.Workplace");
            DropIndex("dbo.WorkOrder", new[] { "WorkplaceId" });
            AddColumn("dbo.Assembly", "WorkplaceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Assembly", "WorkplaceId");
            AddForeignKey("dbo.Assembly", "WorkplaceId", "dbo.Workplace", "Id", cascadeDelete: true);
            DropColumn("dbo.WorkOrder", "WorkplaceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkOrder", "WorkplaceId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Assembly", "WorkplaceId", "dbo.Workplace");
            DropIndex("dbo.Assembly", new[] { "WorkplaceId" });
            DropColumn("dbo.Assembly", "WorkplaceId");
            CreateIndex("dbo.WorkOrder", "WorkplaceId");
            AddForeignKey("dbo.WorkOrder", "WorkplaceId", "dbo.Workplace", "Id", cascadeDelete: true);
        }
    }
}
