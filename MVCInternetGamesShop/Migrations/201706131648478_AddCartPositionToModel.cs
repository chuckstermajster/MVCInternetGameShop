namespace MVCInternetGamesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCartPositionToModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartPossitions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        PriceOfItem = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Game_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.Game_Id)
                .Index(t => t.Game_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartPossitions", "Game_Id", "dbo.Games");
            DropIndex("dbo.CartPossitions", new[] { "Game_Id" });
            DropTable("dbo.CartPossitions");
        }
    }
}
