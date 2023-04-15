namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateproduct3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "WriterId", c => c.Int());
            CreateIndex("dbo.Products", "WriterId");
            AddForeignKey("dbo.Products", "WriterId", "dbo.Writers", "WriterId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "WriterId", "dbo.Writers");
            DropIndex("dbo.Products", new[] { "WriterId" });
            DropColumn("dbo.Products", "WriterId");
        }
    }
}
