using Microsoft.AspNetCore.Identity;

namespace Time_OFF_System.Models
{
    public class AppUser:IdentityUser
    {
        public string name { get; set; }
        public int salary { get; set; }
        public String Department { get; set; }
        public DateTime HireDate { get; set; }

        public string ImagePath { get; set; }

        // public AppUser Manager {get; set;}
        //public ICollection<AppUser> Employees { get; set; }
    }
}
