using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aditya.Models.Page
{
    public class Section
    {
        [Key]
        public int SectionId { get; set; }

        [Required(ErrorMessage = "Please enter section Content")]
        public string SectionContent { get; set; }

        public int PageContentId { get; set; }
        public virtual PageContent PageContent { get; set; }
    }
}