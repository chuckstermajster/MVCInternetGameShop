namespace MVCInternetGamesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAnnotationsFromAddress : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "Street", c => c.String());
            AlterColumn("dbo.Addresses", "PostCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addresses", "PostCode", c => c.String(nullable: false));
            AlterColumn("dbo.Addresses", "Street", c => c.String(nullable: false));
        }
    }
}
