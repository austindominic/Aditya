using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aditya.Models.Page
{
    public class Testimonials
    {
        [Key]
        public int TestimonialsId { get; set; }

        public string UserImage { get; set; }

        [Required(ErrorMessage = "Please enter your UserName!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter your UserDescription!")]
        public string UserDescription { get; set; }

        [Required(ErrorMessage = "Please enter your Testimonial!")]
        public String Testimonial { get; set; }

        public int PageContentId { get; set; }
        public virtual PageContent PageContent { get; set; }
    }
}