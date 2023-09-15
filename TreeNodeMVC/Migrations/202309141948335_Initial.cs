namespace TreeNodeMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Categories", name: "Pid", newName: "ParentID");
            RenameIndex(table: "dbo.Categories", name: "IX_Pid", newName: "IX_ParentID");
            DropColumn("dbo.Categories", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Description", c => c.String());
            RenameIndex(table: "dbo.Categories", name: "IX_ParentID", newName: "IX_Pid");
            RenameColumn(table: "dbo.Categories", name: "ParentID", newName: "Pid");
        }
    }
}
