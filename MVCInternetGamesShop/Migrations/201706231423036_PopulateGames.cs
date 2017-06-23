namespace MVCInternetGamesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGames : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Games ON");
            Sql("INSERT INTO Games (Id, Name, Price, ImageName, PlatformId, IsBestseller, ReleaseDate) VALUES (1, 'Tomb Raider', 200, 'RiseOfTheTombRider.jpg', 1, 1, 20-06-2015)");
            Sql("INSERT INTO Games (Id, Name, Price, ImageName, PlatformId, IsBestseller, ReleaseDate) VALUES (2, 'Tomb Raider', 200, 'TombRaider.jpg', 2, 1, 22-06-2015)");
            Sql("INSERT INTO Games (Id, Name, Price, ImageName, PlatformId, IsBestseller, ReleaseDate) VALUES (3, 'Horizon Zero Dawn', 250, 'HorizonZeroDawn.jpg', 1, 1, 20-01-2017)");
            Sql("INSERT INTO Games (Id, Name, Price, ImageName, PlatformId, IsBestseller, ReleaseDate) VALUES (4, 'FEAR', 100, 'FEAR.jpg', 2, 0, 10-02-2011)");
            Sql("INSERT INTO Games (Id, Name, Price, ImageName, PlatformId, IsBestseller, ReleaseDate) VALUES (5, 'Sleeping Dogs', 230, 'SleepingDogs.jpg', 2, 0, 20-04-2014)");
            Sql("SET IDENTITY_INSERT Games OFF");
        }
        
        public override void Down()
        {
        }
    }
}
