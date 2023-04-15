namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_district : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        DisrictId = c.Int(nullable: false, identity: true),
                        DistrictName = c.String(maxLength: 30),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DisrictId)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Districts", "CityId", "dbo.Cities");
            DropIndex("dbo.Districts", new[] { "CityId" });
            DropTable("dbo.Districts");
        }
    }
}
