namespace MVCInternetGamesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserIdentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.AspNetUsers", new[] { "Address_Id" });
            AddColumn("dbo.AspNetUsers", "City", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Street", c => c.String());
            AddColumn("dbo.AspNetUsers", "StreetNumber", c => c.Int());
            AddColumn("dbo.AspNetUsers", "HouseNumber", c => c.Int());
            AddColumn("dbo.AspNetUsers", "PostCode", c => c.String());
            DropColumn("dbo.AspNetUsers", "Address_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Address_Id", c => c.Int());
            DropColumn("dbo.AspNetUsers", "PostCode");
            DropColumn("dbo.AspNetUsers", "HouseNumber");
            DropColumn("dbo.AspNetUsers", "StreetNumber");
            DropColumn("dbo.AspNetUsers", "Street");
            DropColumn("dbo.AspNetUsers", "City");
            CreateIndex("dbo.AspNetUsers", "Address_Id");
            AddForeignKey("dbo.AspNetUsers", "Address_Id", "dbo.Addresses", "Id");
        }
    }
}
