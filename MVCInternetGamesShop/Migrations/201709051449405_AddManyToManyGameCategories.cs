namespace MVCInternetGamesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddManyToManyGameCategories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameCategories",
                c => new
                    {
                        GameID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        Category_Id = c.Byte(),
                    })
                .PrimaryKey(t => new { t.GameID, t.CategoryID })
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Games", t => t.GameID, cascadeDelete: true)
                .Index(t => t.GameID)
                .Index(t => t.Category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameCategories", "GameID", "dbo.Games");
            DropForeignKey("dbo.GameCategories", "Category_Id", "dbo.Categories");
            DropIndex("dbo.GameCategories", new[] { "Category_Id" });
            DropIndex("dbo.GameCategories", new[] { "GameID" });
            DropTable("dbo.GameCategories");
        }
    }
}
