namespace MVCInternetGamesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderPositionToModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderPositions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        GameId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.GameId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderPositions", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderPositions", "GameId", "dbo.Games");
            DropIndex("dbo.OrderPositions", new[] { "GameId" });
            DropIndex("dbo.OrderPositions", new[] { "OrderId" });
            DropTable("dbo.OrderPositions");
        }
    }
}
