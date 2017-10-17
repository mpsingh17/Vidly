namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4d23ad53-919a-461d-846d-b885b842bde9', N'admin@vidly.com', 0, N'AA6/EtLEAbIGLuqdFC8reNAwaCAmRQ6LobRUizXeaEr5LccGgs3Y0kR45W0OD0VSpQ==', N'd777488e-b56d-4d57-9778-facfc1f04e18', 9855207302, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'65db4f20-a4e5-4142-a386-ca3837536e61', N'guest@vidly.com', 0, N'ABVwoS+eUZSfIIvQkWmXzcoEr+LiHpVr69a/xEnZcFcmFxXaGaQQMbeUHyUFvmuHhQ==', N'0dadb0c4-691b-4432-944c-247bb12ebe09', 9855207301, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'8e85625f-0651-43e3-ab62-593619550800', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4d23ad53-919a-461d-846d-b885b842bde9', N'8e85625f-0651-43e3-ab62-593619550800')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
