namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_comment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "CommentDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Comments", "ProductId", c => c.Int());
            CreateIndex("dbo.Comments", "ProductId");
            AddForeignKey("dbo.Comments", "ProductId", "dbo.Products", "ProductId");
           
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "CommnentDate", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Comments", "ProductId", "dbo.Products");
            DropIndex("dbo.Comments", new[] { "ProductId" });
            DropColumn("dbo.Comments", "ProductId");
            DropColumn("dbo.Comments", "CommentDate");
        }
    }
}
