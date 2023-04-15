namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _update_historyStatus2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HistoryOfProducts", "HistoryStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HistoryOfProducts", "HistoryStatus");
        }
    }
}
