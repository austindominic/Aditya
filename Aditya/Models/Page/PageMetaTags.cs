using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aditya.Models.Page
{
    public class PageMetaTags
    {
        [Key]
        public int PageMetaTagId { get; set; }

        [Required(ErrorMessage = "Meta Name is Required")]
        [StringLength(50)]
        public string MetaName { get; set; }

        [Required(ErrorMessage = "Meta Description is Required")]
        [StringLength(250)]
        public string MetaDescription { get; set; }

        public int PageContentId { get; set; }
        public virtual PageContent PageContent { get; set; }
    }
}