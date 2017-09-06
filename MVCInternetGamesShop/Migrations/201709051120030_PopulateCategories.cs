namespace MVCInternetGamesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategories : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Id, Name) VALUES (1, 'Akcja')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (2, 'Przygodowe')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (3, 'Horror')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (4, 'Logiczne')");
        }
        
        public override void Down()
        {
        }
    }
}
