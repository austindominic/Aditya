namespace Aditya.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _intial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationForms",
                c => new
                    {
                        ApplicationId = c.Int(nullable: false, identity: true),
                        CompleteName = c.String(nullable: false, maxLength: 150),
                        PhoneNumber = c.String(nullable: false),
                        UserEmailId = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ApplicationId);
            
            CreateTable(
                "dbo.BlogCategories",
                c => new
                    {
                        BlogCategoryId = c.Int(nullable: false, identity: true),
                        BlogCategoryName = c.String(nullable: false, maxLength: 150),
                        BackgroundImage = c.String(),
                    })
                .PrimaryKey(t => t.BlogCategoryId);
            
            CreateTable(
                "dbo.BlogContents",
                c => new
                    {
                        BlogContentId = c.Int(nullable: false, identity: true),
                        BlogCaption = c.String(nullable: false, maxLength: 150),
                        BlogMainContent = c.String(nullable: false),
                        BackgroundImage = c.String(nullable: false),
                        BlogTags = c.String(),
                        BlogUrl = c.String(nullable: false),
                        UserId = c.Guid(nullable: false),
                        isApproved = c.Boolean(nullable: false),
                        BlogCreatedDate = c.DateTime(nullable: false),
                        BlogPostingDate = c.DateTime(nullable: false),
                        BlogCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BlogContentId)
                .ForeignKey("dbo.BlogCategories", t => t.BlogCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.UserMains", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.BlogCategoryId);
            
            CreateTable(
                "dbo.BlogSections",
                c => new
                    {
                        SectionId = c.Int(nullable: false, identity: true),
                        SectionName = c.String(),
                        SectionContent = c.String(nullable: false),
                        Order = c.Int(nullable: false),
                        BlogContentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SectionId)
                .ForeignKey("dbo.BlogContents", t => t.BlogContentId, cascadeDelete: true)
                .Index(t => t.BlogContentId);
            
            CreateTable(
                "dbo.BlogTagsMappings",
                c => new
                    {
                        BlogTagsMappingID = c.Int(nullable: false, identity: true),
                        BlogContentId = c.Int(nullable: false),
                        BlogTagsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BlogTagsMappingID)
                .ForeignKey("dbo.BlogContents", t => t.BlogContentId, cascadeDelete: true)
                .ForeignKey("dbo.BlogTagsMains", t => t.BlogTagsId, cascadeDelete: true)
                .Index(t => t.BlogContentId)
                .Index(t => t.BlogTagsId);
            
            CreateTable(
                "dbo.BlogTagsMains",
                c => new
                    {
                        BlogTagsId = c.Int(nullable: false, identity: true),
                        BlogTagsName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BlogTagsId);
            
            CreateTable(
                "dbo.UserComments",
                c => new
                    {
                        UserCommentsId = c.Int(nullable: false, identity: true),
                        UserComment = c.String(nullable: false, maxLength: 250),
                        UserCommentsIDLink = c.Int(nullable: false),
                        StageNumber = c.Int(nullable: false),
                        isApproved = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UserId = c.Guid(nullable: false),
                        BlogContentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserCommentsId)
                .ForeignKey("dbo.BlogContents", t => t.BlogContentId, cascadeDelete: true)
                .ForeignKey("dbo.UserMains", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.BlogContentId);
            
            CreateTable(
                "dbo.UserMains",
                c => new
                    {
                        UserId = c.Guid(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 150),
                        UserEmailId = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 255),
                        UserStatusId = c.Int(nullable: false),
                        UserRoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.UserRoles", t => t.UserRoleId, cascadeDelete: true)
                .ForeignKey("dbo.UserStatus", t => t.UserStatusId, cascadeDelete: true)
                .Index(t => t.UserStatusId)
                .Index(t => t.UserRoleId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserRoleId = c.Int(nullable: false, identity: true),
                        UserRoleName = c.String(),
                    })
                .PrimaryKey(t => t.UserRoleId);
            
            CreateTable(
                "dbo.UserStatus",
                c => new
                    {
                        UserStatusId = c.Int(nullable: false, identity: true),
                        UserStatusName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserStatusId);
            
            CreateTable(
                "dbo.DailyMessages",
                c => new
                    {
                        DailyMessageId = c.Int(nullable: false, identity: true),
                        DailyMessageContent = c.String(nullable: false, maxLength: 150),
                        DailyMessageOwner = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DailyMessageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserComments", "UserId", "dbo.UserMains");
            DropForeignKey("dbo.UserMains", "UserStatusId", "dbo.UserStatus");
            DropForeignKey("dbo.UserMains", "UserRoleId", "dbo.UserRoles");
            DropForeignKey("dbo.BlogContents", "UserId", "dbo.UserMains");
            DropForeignKey("dbo.UserComments", "BlogContentId", "dbo.BlogContents");
            DropForeignKey("dbo.BlogTagsMappings", "BlogTagsId", "dbo.BlogTagsMains");
            DropForeignKey("dbo.BlogTagsMappings", "BlogContentId", "dbo.BlogContents");
            DropForeignKey("dbo.BlogSections", "BlogContentId", "dbo.BlogContents");
            DropForeignKey("dbo.BlogContents", "BlogCategoryId", "dbo.BlogCategories");
            DropIndex("dbo.UserMains", new[] { "UserRoleId" });
            DropIndex("dbo.UserMains", new[] { "UserStatusId" });
            DropIndex("dbo.UserComments", new[] { "BlogContentId" });
            DropIndex("dbo.UserComments", new[] { "UserId" });
            DropIndex("dbo.BlogTagsMappings", new[] { "BlogTagsId" });
            DropIndex("dbo.BlogTagsMappings", new[] { "BlogContentId" });
            DropIndex("dbo.BlogSections", new[] { "BlogContentId" });
            DropIndex("dbo.BlogContents", new[] { "BlogCategoryId" });
            DropIndex("dbo.BlogContents", new[] { "UserId" });
            DropTable("dbo.DailyMessages");
            DropTable("dbo.UserStatus");
            DropTable("dbo.UserRoles");
            DropTable("dbo.UserMains");
            DropTable("dbo.UserComments");
            DropTable("dbo.BlogTagsMains");
            DropTable("dbo.BlogTagsMappings");
            DropTable("dbo.BlogSections");
            DropTable("dbo.BlogContents");
            DropTable("dbo.BlogCategories");
            DropTable("dbo.ApplicationForms");
        }
    }
}
