namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _update_requestStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RequestsOfProducts", "RequestStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RequestsOfProducts", "RequestStatus");
        }
    }
}
