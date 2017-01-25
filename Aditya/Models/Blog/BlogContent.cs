using Aditya.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aditya.Models.Blog
{
    public class BlogContent
    {

        [Key]
        public int BlogContentId { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage = "Please add an Caption.")]
        public string BlogCaption { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Please add an Blog Main Content.")]
        public string BlogMainContent { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Please add an Background Image Content.")]
        public string BackgroundImage { get; set; }

        public string BlogTags { get; set; }

        [Required]
        public string BlogUrl { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public bool isApproved { get; set; }

        public DateTime BlogCreatedDate { get; set; }

        public DateTime BlogPostingDate { get; set; }

        public int BlogCategoryId { get; set; }

        public virtual BlogCategory blogCategory { get; set; }
        public virtual List<BlogTagsMapping> blogTagsMapping { get; set; }
        public virtual List<UserComments> UserComments { get; set; }
        public virtual List<BlogSection> BlogSection { get; set; }
        public virtual UserMain UserMain { get; set; }
    }
}