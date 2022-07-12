using System.ComponentModel.DataAnnotations;

namespace Time_OFF_System.Data.ViewModels
{
    public class AppuserVM
    {
        [Display(Name ="First Name")]
        public string name { get; set; }
        public string email { get; set; }

        public int salary { get; set; }
        public String Department { get; set; }
        public DateTime HireDate { get; set; }
        public string imagePath { get; set; }  
        public string PhoneNumber { get; set; }

    }
}
