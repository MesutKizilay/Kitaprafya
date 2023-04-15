namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateproduct4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductDescription", c => c.String(maxLength: 2000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ProductDescription", c => c.String(maxLength: 200));
        }
    }
}
