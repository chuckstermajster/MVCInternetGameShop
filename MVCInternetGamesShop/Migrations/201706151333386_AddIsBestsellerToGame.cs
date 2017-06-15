namespace MVCInternetGamesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsBestsellerToGame : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "IsBestseller", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "IsBestseller");
        }
    }
}
