using Aditya.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aditya.Models.Repository.User
{
    public class UserCommentsRepository : Repository<UserComments>
    {
        public List<UserComments> GetBlogComment(int blogContentId)
        {
            return DbSet.Where(t => t.BlogContentId == blogContentId && t.isApproved == true).ToList();
        }
    }
}