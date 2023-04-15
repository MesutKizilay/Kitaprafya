namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _update_city : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Districts", "CityId", "dbo.Cities");
            DropIndex("dbo.Districts", new[] { "CityId" });
            AddColumn("dbo.Cities", "DistrictId", c => c.Int(nullable: false));
            AddColumn("dbo.Cities", "District_DisrictId", c => c.Int());
            CreateIndex("dbo.Cities", "District_DisrictId");
            AddForeignKey("dbo.Cities", "District_DisrictId", "dbo.Districts", "DisrictId");
            DropColumn("dbo.Districts", "CityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Districts", "CityId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Cities", "District_DisrictId", "dbo.Districts");
            DropIndex("dbo.Cities", new[] { "District_DisrictId" });
            DropColumn("dbo.Cities", "District_DisrictId");
            DropColumn("dbo.Cities", "DistrictId");
            CreateIndex("dbo.Districts", "CityId");
            AddForeignKey("dbo.Districts", "CityId", "dbo.Cities", "CityId", cascadeDelete: true);
        }
    }
}
