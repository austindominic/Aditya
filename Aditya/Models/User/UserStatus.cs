using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aditya.Models.User
{
    public class UserStatus
    {
        [Key]
        public int UserStatusId { get; set; }
        [Required]
        public string UserStatusName { get; set; }

        public virtual List<UserMain> userMain { get; set; }
    }
}