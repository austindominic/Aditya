using Aditya.Models.Blog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Aditya.Models.User
{
    public class UserComments
    {
        [Key]
        public int UserCommentsId { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "This field is required")]
        public string UserComment { get; set; }

        public int UserCommentsIDLink { get; set; }

        public int StageNumber { get; set; }
        [Required]
        public bool isApproved { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
        [ForeignKey("UserMain")]
        public Guid UserId { get; set; }
        public int BlogContentId { get; set; }
        public virtual BlogContent BlogContent { get; set; }
        public virtual UserMain UserMain { get; set; }
    }
}