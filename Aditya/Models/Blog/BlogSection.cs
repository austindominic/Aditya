using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aditya.Models.Blog
{
    public class BlogSection
    {

        [Key]
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        [AllowHtml]
        [Required(ErrorMessage = "Please enter section Content")]
        public string SectionContent { get; set; }
        public int Order { get; set; }

        public int BlogContentId { get; set; }
        public virtual BlogContent BlogContent { get; set; }
    }
}