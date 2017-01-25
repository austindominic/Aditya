using Aditya.Models.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aditya.Models.Repository.Page
{
    public class PageContentRepository : Repository<PageContent>
    {
        public List<PageContent> GetByContentName(string contentName)
        {
            return DbSet.Where(p => p.PageUrl.Contains(contentName)).ToList();
        }
    }
}