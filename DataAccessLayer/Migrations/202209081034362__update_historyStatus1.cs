namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _update_historyStatus1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RequestsOfProducts", "HistoryStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.HistoryOfProducts", "HistoryStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HistoryOfProducts", "HistoryStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.RequestsOfProducts", "HistoryStatus");
        }
    }
}
