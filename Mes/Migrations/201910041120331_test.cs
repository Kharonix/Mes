namespace Mes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Assembly", "WorkplaceId", "dbo.Workplace");
            DropIndex("dbo.Assembly", new[] { "WorkplaceId" });
            AlterColumn("dbo.Assembly", "WorkplaceId", c => c.Int());
            CreateIndex("dbo.Assembly", "WorkplaceId");
            AddForeignKey("dbo.Assembly", "WorkplaceId", "dbo.Workplace", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assembly", "WorkplaceId", "dbo.Workplace");
            DropIndex("dbo.Assembly", new[] { "WorkplaceId" });
            AlterColumn("dbo.Assembly", "WorkplaceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Assembly", "WorkplaceId");
            AddForeignKey("dbo.Assembly", "WorkplaceId", "dbo.Workplace", "Id", cascadeDelete: true);
        }
    }
}
