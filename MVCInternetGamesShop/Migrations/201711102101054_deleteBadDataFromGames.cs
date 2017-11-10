namespace MVCInternetGamesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteBadDataFromGames : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Games WHERE ID=2");
            Sql("DELETE FROM Games WHERE ID=3");
            Sql("DELETE FROM Games WHERE ID=4");
            Sql("DELETE FROM Games WHERE ID=5");
        }
        
        public override void Down()
        {
        }
    }
}
