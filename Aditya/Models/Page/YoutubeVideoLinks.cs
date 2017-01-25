using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aditya.Models.Page
{
    public class YoutubeVideoLinks
    {
        [Key]
        public int YtLinkId { get; set; }

        [Required(ErrorMessage = "Source is Required!")]
        [StringLength(250)]
        public string LinkSource { get; set; }

        [Required()]
        public int YTorder { get; set; }

        public int PageContentId { get; set; }
        public virtual PageContent PageContent { get; set; }
    }
}