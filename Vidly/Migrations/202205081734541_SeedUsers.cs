namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8af15fb5-a5cd-419f-97e6-0c881409357f', N'admin2@vidly.com', 0, N'AFiS9iRyrCV8cBuWztv+SP4vuXShWTwnlQEBFTAaq9eajlYZw0pW3yQGJczjN8FJ+A==', N'fb56e435-72e6-4019-8fbd-4a61acef933f', NULL, 0, 0, NULL, 1, 0, N'admin2@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9a3fbfe8-24ca-4576-96d7-5100884463e8', N'admin@vidly.com', 0, N'AEbG4y2+QV1p8u7QzoOrO20inoT3smA99WsGkPSildvHzaGx1xC97UF2aTuSUTJZCg==', N'e0bd3741-28b3-44a2-8e2d-eaf04fdc148f', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c4e75257-c01d-4fe7-8706-f888943e367c', N'guest@vidly.com', 0, N'AIAnnK458rXCAXxlAGC1ra8GOrOJDAJDDcCJeAFTFskRFMCx/ScV4uZaRuk3OPm6cQ==', N'cc4d4941-ef6f-41b0-8b73-fff7f330ebff', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1c6ba325-876c-4c76-9ada-86c096ffe400', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8af15fb5-a5cd-419f-97e6-0c881409357f', N'1c6ba325-876c-4c76-9ada-86c096ffe400')
");
        }
        
        public override void Down()
        {
        }
    }
}
