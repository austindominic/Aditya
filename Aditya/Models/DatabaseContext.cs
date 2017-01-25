using Aditya.Models.Application;
using Aditya.Models.Blog;
using Aditya.Models.Menu;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Aditya.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<MainMenu> MainMenu { get;  set; }

        public System.Data.Entity.DbSet<Aditya.Models.Page.PageContent> PageContents { get; set; }

        public System.Data.Entity.DbSet<Aditya.Models.Page.Section> Sections { get; set; }

        public DbSet<BlogContent> BlogContent { get; set; }
        public DbSet<DailyMessage> DailyMessage { get; set; }
        public DbSet<BlogTagsMain> BlogTags { get; set; }
        public DbSet<ApplicationForm> ApplicationForm { get; set; }
        public DbSet<BlogCategory> BlogCategory { get; set; }
    }
}