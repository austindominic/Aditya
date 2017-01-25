using System.ComponentModel.DataAnnotations;


namespace Aditya.Models.Application
{
    public class ApplicationForm
    {
        [Key]
        public int ApplicationId { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage = "Your Name is Required")]
        public string CompleteName { get; set; }

        [Required(ErrorMessage = "Your must provide a PhoneNumber")]
        [Display(Name = "Mobile Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Your Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string UserEmailId { get; set; }
        [Required(ErrorMessage = "Your gender is Required")]
        public string Gender { get; set; }
        
    
    }
}