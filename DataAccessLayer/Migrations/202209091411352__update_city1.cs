namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _update_city1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cities", "District_DisrictId", "dbo.Districts");
            DropIndex("dbo.Cities", new[] { "District_DisrictId" });
            DropColumn("dbo.Cities", "DistrictId");
            DropColumn("dbo.Cities", "District_DisrictId");
            DropTable("dbo.Districts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        DisrictId = c.Int(nullable: false, identity: true),
                        DistrictName = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.DisrictId);
            
            AddColumn("dbo.Cities", "District_DisrictId", c => c.Int());
            AddColumn("dbo.Cities", "DistrictId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cities", "District_DisrictId");
            AddForeignKey("dbo.Cities", "District_DisrictId", "dbo.Districts", "DisrictId");
        }
    }
}
