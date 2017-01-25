using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aditya.Models.User
{
    public class UserRole
    {
        [Key]
        public int UserRoleId { get; set; }

        public string UserRoleName { get; set; }

        public virtual List<UserMain> userMain { get; set; }
    }
}