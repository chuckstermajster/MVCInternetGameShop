namespace MVCInternetGamesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotationsToOrder : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "Street", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "StreetNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "PostCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "PostCode", c => c.String());
            AlterColumn("dbo.Orders", "StreetNumber", c => c.Int());
            AlterColumn("dbo.Orders", "Street", c => c.String());
            AlterColumn("dbo.Orders", "Name", c => c.String());
        }
    }
}
