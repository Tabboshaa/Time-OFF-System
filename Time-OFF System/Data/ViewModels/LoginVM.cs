using System.ComponentModel.DataAnnotations;

namespace Time_OFF_System.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name ="Email Address")]
        [Required(ErrorMessage ="Email is Required !")]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string password { get; set; }
    }
}
