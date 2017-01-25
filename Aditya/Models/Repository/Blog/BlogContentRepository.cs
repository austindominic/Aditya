using Aditya.Models.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aditya.Models.Repository.Blog
{
    public class BlogContentRepository : Repository<BlogContent>
    {
        public List<BlogContent> GetBlogContentByTags(string TagName)
        {
            return DbSet.Where(n => n.BlogTags.Contains(TagName) && n.BlogPostingDate < DateTime.Now).ToList();
        }

        public List<BlogContent> GetBlogContentByUrl(string url)
        {
            return DbSet.Where(n => n.BlogUrl.Contains(url) && n.BlogPostingDate < DateTime.Now).ToList();
        }

    }
}