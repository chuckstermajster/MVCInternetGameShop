namespace MVCInternetGamesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectTypoInModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CartPossitions", newName: "CartPositions");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.CartPositions", newName: "CartPossitions");
        }
    }
}
