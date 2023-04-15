namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_productsOfUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductsOfUsers",
                c => new
                    {
                        ProductsOfUserId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        SharingStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductsOfUserId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductsOfUsers", "UserId", "dbo.Users");
            DropForeignKey("dbo.ProductsOfUsers", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductsOfUsers", new[] { "UserId" });
            DropIndex("dbo.ProductsOfUsers", new[] { "ProductId" });
            DropTable("dbo.ProductsOfUsers");
        }
    }
}
