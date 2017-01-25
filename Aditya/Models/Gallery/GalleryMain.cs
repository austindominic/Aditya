using Aditya.Models.Page;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aditya.Models.Gallery
{
    public class GalleryMain
    {
        [Key]
        public int GalleryId { get; set; }

        [Required(ErrorMessage = "Input Gallery Name")]
        [StringLength(150)]
        public string GalleryName { get; set; }

        [Required(ErrorMessage = "Input Gallery Image Link")]
        public string GalleryImageLink { get; set; }

        [Required(ErrorMessage = "Input Gallery Message")]
        public string GalleryDescription { get; set; }

        public DateTime CreateDateTime { get; set; }
        public int PageContentId { get; set; }
        public virtual PageContent PageContent { get; set; }
    }
}