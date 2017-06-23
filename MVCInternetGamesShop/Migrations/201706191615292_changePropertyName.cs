namespace MVCInternetGamesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changePropertyName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "ReleaseDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "ReleaseDate");
        }
    }
}
