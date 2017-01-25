namespace Aditya.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MainMenus",
                c => new
                    {
                        MenuItemId = c.Int(nullable: false, identity: true),
                        MenuItemName = c.String(),
                        MenuItemPath = c.String(),
                        MenuRoot = c.String(),
                        MenuOrder = c.Int(nullable: false),
                        ParentItemId = c.Int(),
                        MainMenu_MenuItemId = c.Int(),
                    })
                .PrimaryKey(t => t.MenuItemId)
                .ForeignKey("dbo.MainMenus", t => t.MainMenu_MenuItemId)
                .Index(t => t.MainMenu_MenuItemId);
            
            CreateTable(
                "dbo.PageContents",
                c => new
                    {
                        PageContentId = c.Int(nullable: false, identity: true),
                        PageName = c.String(nullable: false, maxLength: 50),
                        PageTagLine = c.String(nullable: false, maxLength: 50),
                        PageUrl = c.String(nullable: false, maxLength: 250),
                        PageDescription = c.String(nullable: false),
                        BackgroundClass = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PageContentId);
            
            CreateTable(
                "dbo.GalleryMains",
                c => new
                    {
                        GalleryId = c.Int(nullable: false, identity: true),
                        GalleryName = c.String(nullable: false, maxLength: 150),
                        GalleryImageLink = c.String(nullable: false),
                        GalleryDescription = c.String(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                        PageContentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GalleryId)
                .ForeignKey("dbo.PageContents", t => t.PageContentId, cascadeDelete: true)
                .Index(t => t.PageContentId);
            
            CreateTable(
                "dbo.PageMetaTags",
                c => new
                    {
                        PageMetaTagId = c.Int(nullable: false, identity: true),
                        MetaName = c.String(nullable: false, maxLength: 50),
                        MetaDescription = c.String(nullable: false, maxLength: 250),
                        PageContentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PageMetaTagId)
                .ForeignKey("dbo.PageContents", t => t.PageContentId, cascadeDelete: true)
                .Index(t => t.PageContentId);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        SectionId = c.Int(nullable: false, identity: true),
                        SectionContent = c.String(nullable: false),
                        PageContentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SectionId)
                .ForeignKey("dbo.PageContents", t => t.PageContentId, cascadeDelete: true)
                .Index(t => t.PageContentId);
            
            CreateTable(
                "dbo.Testimonials",
                c => new
                    {
                        TestimonialsId = c.Int(nullable: false, identity: true),
                        UserImage = c.String(),
                        UserName = c.String(nullable: false),
                        UserDescription = c.String(nullable: false),
                        Testimonial = c.String(nullable: false),
                        PageContentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TestimonialsId)
                .ForeignKey("dbo.PageContents", t => t.PageContentId, cascadeDelete: true)
                .Index(t => t.PageContentId);
            
            CreateTable(
                "dbo.YoutubeVideoLinks",
                c => new
                    {
                        YtLinkId = c.Int(nullable: false, identity: true),
                        LinkSource = c.String(nullable: false, maxLength: 250),
                        YTorder = c.Int(nullable: false),
                        PageContentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.YtLinkId)
                .ForeignKey("dbo.PageContents", t => t.PageContentId, cascadeDelete: true)
                .Index(t => t.PageContentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.YoutubeVideoLinks", "PageContentId", "dbo.PageContents");
            DropForeignKey("dbo.Testimonials", "PageContentId", "dbo.PageContents");
            DropForeignKey("dbo.Sections", "PageContentId", "dbo.PageContents");
            DropForeignKey("dbo.PageMetaTags", "PageContentId", "dbo.PageContents");
            DropForeignKey("dbo.GalleryMains", "PageContentId", "dbo.PageContents");
            DropForeignKey("dbo.MainMenus", "MainMenu_MenuItemId", "dbo.MainMenus");
            DropIndex("dbo.YoutubeVideoLinks", new[] { "PageContentId" });
            DropIndex("dbo.Testimonials", new[] { "PageContentId" });
            DropIndex("dbo.Sections", new[] { "PageContentId" });
            DropIndex("dbo.PageMetaTags", new[] { "PageContentId" });
            DropIndex("dbo.GalleryMains", new[] { "PageContentId" });
            DropIndex("dbo.MainMenus", new[] { "MainMenu_MenuItemId" });
            DropTable("dbo.YoutubeVideoLinks");
            DropTable("dbo.Testimonials");
            DropTable("dbo.Sections");
            DropTable("dbo.PageMetaTags");
            DropTable("dbo.GalleryMains");
            DropTable("dbo.PageContents");
            DropTable("dbo.MainMenus");
        }
    }
}
