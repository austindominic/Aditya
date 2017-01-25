using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Aditya.Models.Blog
{
    public class BlogTagsMapping
    {

        [Key]
        public int BlogTagsMappingID { get; set; }

        public int BlogContentId { get; set; }
        public int BlogTagsId { get; set; }

        [ForeignKey("BlogContentId")]
        public virtual BlogContent BlogContent { get; set; }

        [ForeignKey("BlogTagsId")]
        public virtual BlogTagsMain BlogTagsMain { get; set; }
    }
}