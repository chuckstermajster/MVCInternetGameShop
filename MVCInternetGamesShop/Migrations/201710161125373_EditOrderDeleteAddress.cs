namespace MVCInternetGamesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditOrderDeleteAddress : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.Orders", new[] { "Address_Id" });
            DropColumn("dbo.Orders", "Address_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Address_Id", c => c.Int());
            CreateIndex("dbo.Orders", "Address_Id");
            AddForeignKey("dbo.Orders", "Address_Id", "dbo.Addresses", "Id");
        }
    }
}
