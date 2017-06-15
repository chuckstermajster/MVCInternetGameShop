namespace MVCInternetGamesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPlatformToModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Platforms",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Games", "ImageName", c => c.String());
            AddColumn("dbo.Games", "Platform_Id", c => c.Byte());
            CreateIndex("dbo.Games", "Platform_Id");
            AddForeignKey("dbo.Games", "Platform_Id", "dbo.Platforms", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "Platform_Id", "dbo.Platforms");
            DropIndex("dbo.Games", new[] { "Platform_Id" });
            DropColumn("dbo.Games", "Platform_Id");
            DropColumn("dbo.Games", "ImageName");
            DropTable("dbo.Platforms");
        }
    }
}
