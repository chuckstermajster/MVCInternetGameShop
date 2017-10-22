namespace MVCInternetGamesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdFieldToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserId");
        }
    }
}
