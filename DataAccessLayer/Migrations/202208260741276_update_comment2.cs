namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_comment2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Comments", new[] { "CategoryId" });
            DropColumn("dbo.Comments", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "CategoryId");
            AddForeignKey("dbo.Comments", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
        }
    }
}
