namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _add_requestOfProducts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RequestsOfProducts",
                c => new
                    {
                        RequestOfProductId = c.Int(nullable: false, identity: true),
                        OwnerUserId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        RequestNote = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.RequestOfProductId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RequestsOfProducts", "UserId", "dbo.Users");
            DropForeignKey("dbo.RequestsOfProducts", "ProductId", "dbo.Products");
            DropIndex("dbo.RequestsOfProducts", new[] { "ProductId" });
            DropIndex("dbo.RequestsOfProducts", new[] { "UserId" });
            DropTable("dbo.RequestsOfProducts");
        }
    }
}
