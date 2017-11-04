namespace MVCInternetGamesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeGamePlatformIdToRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "PlatformId", "dbo.Platforms");
            DropIndex("dbo.Games", new[] { "PlatformId" });
            AlterColumn("dbo.Games", "PlatformId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Games", "PlatformId");
            AddForeignKey("dbo.Games", "PlatformId", "dbo.Platforms", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "PlatformId", "dbo.Platforms");
            DropIndex("dbo.Games", new[] { "PlatformId" });
            AlterColumn("dbo.Games", "PlatformId", c => c.Byte());
            CreateIndex("dbo.Games", "PlatformId");
            AddForeignKey("dbo.Games", "PlatformId", "dbo.Platforms", "Id");
        }
    }
}
