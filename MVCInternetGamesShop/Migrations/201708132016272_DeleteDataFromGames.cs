namespace MVCInternetGamesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteDataFromGames : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Games WHERE ID=1");
        }
        
        public override void Down()
        {
        }
    }
}
