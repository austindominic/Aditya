using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aditya.Models.Blog
{
    public class BlogTagsMain
    {
        [Key]
        public int BlogTagsId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string BlogTagsName { get; set; }

        public virtual List<BlogTagsMapping> BlogTagsMapping { get; set; }
    }
}