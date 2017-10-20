namespace MVCInternetGamesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnotationToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Street", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "StreetNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "PostCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "PostCode", c => c.String());
            AlterColumn("dbo.AspNetUsers", "StreetNumber", c => c.Int());
            AlterColumn("dbo.AspNetUsers", "Street", c => c.String());
        }
    }
}
