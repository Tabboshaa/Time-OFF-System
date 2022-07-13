using System.ComponentModel.DataAnnotations;

namespace Time_OFF_System.Data.ViewModels
{
    public class AppuserVM
    {
        [Display(Name ="First Name:")]
        public string name { get; set; }
        [Display(Name="Email:")]
        public string email { get; set; }

        [Display(Name ="Salary:")]
        public int salary { get; set; }
        [Display(Name = "Department:")]
        public String Department { get; set; }
        public DateTime HireDate { get; set; }
        public string imagePath { get; set; }
        [Display(Name = "Phone Number:")]
        public string PhoneNumber { get; set; }

    }
}
