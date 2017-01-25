using Aditya.Models.Gallery;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aditya.Models.Page
{
    public class PageContent
    {
        public int PageContentId { get; set; }

        [Required(ErrorMessage = "Page Name is required!")]
        [StringLength(50)]
        public string PageName { get; set; }

        [Required(ErrorMessage = "Page Tag Line is required!")]
        [StringLength(50)]
        public string PageTagLine { get; set; }

        [Required(ErrorMessage = "Page Url is required!")]
        [StringLength(250)]
        public string PageUrl { get; set; }

        [Required(ErrorMessage = "Page Description is required!")]
        public string PageDescription { get; set; }

        [Required(ErrorMessage = "Back Ground Class is required!")]
        public string BackgroundClass { get; set; }

        
        public virtual List<YoutubeVideoLinks> YoutubeVideoLinks { get; set; }
        public virtual List<PageMetaTags> PageMetaTags { get; set; }

        public virtual List<Section> Sections { get; set; }
        public virtual List<Testimonials> Testimonialse { get; set; }

        public virtual List<GalleryMain> GalleryMain { get; set; }

     
    }
}