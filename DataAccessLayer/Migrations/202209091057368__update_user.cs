namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _update_user : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "City_CityId", "dbo.Cities");
            DropIndex("dbo.Users", new[] { "City_CityId" });
            DropColumn("dbo.Users", "CityId");
            RenameColumn(table: "dbo.Users", name: "City_CityId", newName: "CityId");
            AlterColumn("dbo.Users", "CityId", c => c.Int(nullable: true));
            AlterColumn("dbo.Users", "CityId", c => c.Int(nullable: true));
            CreateIndex("dbo.Users", "CityId");
            AddForeignKey("dbo.Users", "CityId", "dbo.Cities", "CityId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "CityId", "dbo.Cities");
            DropIndex("dbo.Users", new[] { "CityId" });
            AlterColumn("dbo.Users", "CityId", c => c.Int());
            AlterColumn("dbo.Users", "CityId", c => c.String());
            RenameColumn(table: "dbo.Users", name: "CityId", newName: "City_CityId");
            AddColumn("dbo.Users", "CityId", c => c.String());
            CreateIndex("dbo.Users", "City_CityId");
            AddForeignKey("dbo.Users", "City_CityId", "dbo.Cities", "CityId");
        }
    }
}
