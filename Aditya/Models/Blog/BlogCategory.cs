using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aditya.Models.Blog
{
    public class BlogCategory
    {

        [Key]
        public int BlogCategoryId { get; set; }

        [Required(ErrorMessage = "Category Name is Required")]
        [StringLength(150)]
        public string BlogCategoryName { get; set; }

        public string BackgroundImage { get; set; }
        public virtual List<BlogContent> blogContent { get; set; }
    }
}