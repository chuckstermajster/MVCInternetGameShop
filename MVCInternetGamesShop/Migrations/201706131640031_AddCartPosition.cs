namespace MVCInternetGamesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCartPosition : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropColumn("dbo.Orders", "UserId");
            RenameColumn(table: "dbo.Orders", name: "User_Id", newName: "UserId");
            AddColumn("dbo.Games", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "CreationTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Orders", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Orders", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Orders", new[] { "UserId" });
            AlterColumn("dbo.Orders", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "CreationTime");
            DropColumn("dbo.Games", "Price");
            RenameColumn(table: "dbo.Orders", name: "UserId", newName: "User_Id");
            AddColumn("dbo.Orders", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "User_Id");
        }
    }
}
