namespace MVCInternetGamesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNullableIntToAddress : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "StreetNumber", c => c.Int());
            AlterColumn("dbo.Addresses", "HouseNumber", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addresses", "HouseNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Addresses", "StreetNumber", c => c.Int(nullable: false));
        }
    }
}
