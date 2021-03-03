namespace Mes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_AssemlyComponent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssemblyComponents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Count = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AssembleId = c.Int(nullable: false),
                        WorkplaceId = c.Int(nullable: false),
                        Assembly_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Assemblies", t => t.Assembly_Id)
                .ForeignKey("dbo.Workplaces", t => t.WorkplaceId, cascadeDelete: true)
                .Index(t => t.WorkplaceId)
                .Index(t => t.Assembly_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssemblyComponents", "WorkplaceId", "dbo.Workplaces");
            DropForeignKey("dbo.AssemblyComponents", "Assembly_Id", "dbo.Assemblies");
            DropIndex("dbo.AssemblyComponents", new[] { "Assembly_Id" });
            DropIndex("dbo.AssemblyComponents", new[] { "WorkplaceId" });
            DropTable("dbo.AssemblyComponents");
        }
    }
}
