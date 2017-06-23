namespace MVCInternetGamesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPlatformIDProperty : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "Platform_Id", "dbo.Platforms");
            DropIndex("dbo.Games", new[] { "Platform_Id" });
            RenameColumn(table: "dbo.Games", name: "Platform_Id", newName: "PlatformId");
            AlterColumn("dbo.Games", "PlatformId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Games", "PlatformId");
            AddForeignKey("dbo.Games", "PlatformId", "dbo.Platforms", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "PlatformId", "dbo.Platforms");
            DropIndex("dbo.Games", new[] { "PlatformId" });
            AlterColumn("dbo.Games", "PlatformId", c => c.Byte());
            RenameColumn(table: "dbo.Games", name: "PlatformId", newName: "Platform_Id");
            CreateIndex("dbo.Games", "Platform_Id");
            AddForeignKey("dbo.Games", "Platform_Id", "dbo.Platforms", "Id");
        }
    }
}
