namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _add_historyOfProduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HistoryOfProducts",
                c => new
                    {
                        HistoryOfProductId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ShareDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.HistoryOfProductId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HistoryOfProducts", "UserId", "dbo.Users");
            DropForeignKey("dbo.HistoryOfProducts", "ProductId", "dbo.Products");
            DropIndex("dbo.HistoryOfProducts", new[] { "ProductId" });
            DropIndex("dbo.HistoryOfProducts", new[] { "UserId" });
            DropTable("dbo.HistoryOfProducts");
        }
    }
}
