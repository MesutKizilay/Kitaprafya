namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_historyOfProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HistoryOfProducts", "OwnerUserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HistoryOfProducts", "OwnerUserId");
        }
    }
}
