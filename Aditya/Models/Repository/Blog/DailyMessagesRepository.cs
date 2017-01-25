using Aditya.Models.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aditya.Models.Repository.Blog
{
    public class DailyMessagesRepository : Repository<DailyMessage>
    {
        public List<DailyMessage> TodaysMessage()
        {
            return DbSet.OrderByDescending(t => t.DailyMessageId).Take(1).ToList();
        }
    }
}