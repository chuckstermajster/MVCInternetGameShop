namespace MVCInternetGamesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsersAndRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Name], [City], [Street], [StreetNumber], [HouseNumber], [PostCode]) VALUES (N'705e5602-ec3b-424b-979f-7d686321c1ba', N'admin@gmail.com', 0, N'AMfdYgvACSFiB/I14rEIZAnruiA5i3ekSIcxLylY5KIzKhfxVthNQyyEEPPt5RpqdQ==', N'459e9447-3436-4d9f-ae83-cb7e0b5d35ed', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com', N'Mateusz', N'AdminTown', N'adminowa', 1, NULL, N'super-admin')
INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Name], [City], [Street], [StreetNumber], [HouseNumber], [PostCode]) VALUES(N'a7441213-d805-40c2-bf65-3ae145fd9c21', N'quest@gmail.com', 0, N'AEm/6HxOjLudOWqzXa5QXW2LZekjncmnyIntnzcuWl0JBL/dUQpkbo4nUzvyKDOShg==', N'2b24aec3-ea20-44d5-afef-501bd3926e08', NULL, 0, 0, NULL, 1, 0, N'quest@gmail.com', N'j', N'a', N'1, 22', 22, 22, N'41-200')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0ee953de-7981-4ad9-8aea-3949202c5c05', N'CanManageStore')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'705e5602-ec3b-424b-979f-7d686321c1ba', N'0ee953de-7981-4ad9-8aea-3949202c5c05')

");



        }

    public override void Down()
        {
        }
    }
}
