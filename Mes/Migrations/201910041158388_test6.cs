namespace Mes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test6 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Assembly", name: "WorkplaceId", newName: "Workplace_Id");
            RenameIndex(table: "dbo.Assembly", name: "IX_WorkplaceId", newName: "IX_Workplace_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Assembly", name: "IX_Workplace_Id", newName: "IX_WorkplaceId");
            RenameColumn(table: "dbo.Assembly", name: "Workplace_Id", newName: "WorkplaceId");
        }
    }
}
