using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aditya.Models.Blog
{
    public class DailyMessage
    {

        [Key]
        public int DailyMessageId { get; set; }

        [Required(ErrorMessage = "Kindly Fill this ")]
        [StringLength(150)]
        public string DailyMessageContent { get; set; }

        [Required]
        public string DailyMessageOwner { get; set; }
    }
}