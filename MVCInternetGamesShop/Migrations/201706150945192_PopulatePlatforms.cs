namespace MVCInternetGamesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatePlatforms : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Platforms (Id, Name) VALUES (1, 'Playstation 4')");
            Sql("INSERT INTO Platforms (Id, Name) VALUES (2, 'PC')");
            Sql("INSERT INTO Platforms (Id, Name) VALUES (3, 'XBOX ONE')");
        }
        
        public override void Down()
        {
        }
    }
}
