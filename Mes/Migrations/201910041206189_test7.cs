namespace Mes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test7 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Assembly", name: "Workplace_Id", newName: "WorkplaceId");
            RenameIndex(table: "dbo.Assembly", name: "IX_Workplace_Id", newName: "IX_WorkplaceId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Assembly", name: "IX_WorkplaceId", newName: "IX_Workplace_Id");
            RenameColumn(table: "dbo.Assembly", name: "WorkplaceId", newName: "Workplace_Id");
        }
    }
}
