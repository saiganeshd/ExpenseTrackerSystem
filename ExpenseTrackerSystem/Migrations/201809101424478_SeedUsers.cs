namespace ExpenseTrackerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5d194ea3-9655-4f8c-98d9-00bbc3d89f78', N'admin@expense.com', 0, N'APzi2aIIkhcYW99ZAXNeJ9J2k8lgY0S5pYBR2BDiVE+PT7sYXzIOfxPpKROPW+5Gug==', N'bde4fa1b-035e-4cd7-8157-fc3fd827736a', NULL, 0, 0, NULL, 1, 0, N'admin@expense.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6a0a7f1c-eb32-48ae-884b-483bd3cc682c', N'admin@gmail.com', 0, N'ABYYenUfleKBnv4Q3rAXVC1aZdXJMpqwOtkKPVa01G0AUyWAO7NuutoB6s/XEVUl/A==', N'70592111-17d7-4c75-9dff-308ff5a22ccf', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a2b76829-e8d8-4caa-8c2e-ef6f36d98915', N'xyz@xyz.com', 0, N'AFMWkqi2S/AbGi/Z/pi710GmSmeHtcZH+EgZLjw75px3iAnIs+7occmoxrrr40bErA==', N'96cdae49-5f6b-4d61-add4-e15cd3998425', NULL, 0, 0, NULL, 1, 0, N'xyz@xyz.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a2dd1b24-196a-479e-9f6b-42b8548c9c06', N'abc@abc.com', 0, N'AOZyz77SZGxv/JcqLJk5pU1oRUmCnvNh5jvhiI9i6ujt5LC3hpgSjj8K10L2EUy+gA==', N'cd67ec2f-0277-48ac-9ed2-17ba1c217279', NULL, 0, 0, NULL, 1, 0, N'abc@abc.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cd2fbcf0-319d-411b-90d9-4f306bd5e7c1', N'123@gmail.com', 0, N'AEU5FFetTjobj3Cw1JX6qxGqJGR3d1jp14bzQzCuBygvbZFup9yPisXCOUVjInZ5HQ==', N'8f4efc6e-7af7-4cc0-b3eb-8aa36f3663e0', NULL, 0, 0, NULL, 1, 0, N'123@gmail.com')


INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1d7f4386-d308-4d08-819c-04791640121d', N'CanManageExpenses')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5d194ea3-9655-4f8c-98d9-00bbc3d89f78', N'1d7f4386-d308-4d08-819c-04791640121d')
");
        }
        
        public override void Down()
        {
        }
    }
}
