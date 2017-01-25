using Aditya.Models.Blog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Aditya.Models.User
{
    public class UserMain
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage = "Your Name is Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Your Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string UserEmailId { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int UserStatusId { get; set; }
        public virtual UserStatus userStatus { get; set; }

        public int UserRoleId { get; set; }
        public virtual UserRole userRole { get; set; }
        public virtual List<UserComments> UserComments { get; set; }
        public virtual List<BlogContent> BlogContent { get; set; }
    }
}