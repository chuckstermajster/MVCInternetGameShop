namespace MVCInternetGamesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Name", c => c.String());
            AddColumn("dbo.Orders", "City", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "Street", c => c.String());
            AddColumn("dbo.Orders", "StreetNumber", c => c.Int());
            AddColumn("dbo.Orders", "HouseNumber", c => c.Int());
            AddColumn("dbo.Orders", "PostCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "PostCode");
            DropColumn("dbo.Orders", "HouseNumber");
            DropColumn("dbo.Orders", "StreetNumber");
            DropColumn("dbo.Orders", "Street");
            DropColumn("dbo.Orders", "City");
            DropColumn("dbo.Orders", "Name");
        }
    }
}
