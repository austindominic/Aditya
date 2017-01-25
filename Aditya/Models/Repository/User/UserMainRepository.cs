using Aditya.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aditya.Models.Repository.User
{
    public class UserMainRepository : Repository<UserMain>
    {
        public List<UserMain> DuplicateUserCheck(string userName, string userEmail)
        {
            return DbSet.Where(t => t.UserName == userName || t.UserEmailId == userEmail).ToList();
        }

        public List<UserMain> LoginToTheSite(string userEmailID, string Password)
        {
            return DbSet.Where(t => t.UserEmailId == userEmailID && t.Password == Password).ToList();
        }
    }
}