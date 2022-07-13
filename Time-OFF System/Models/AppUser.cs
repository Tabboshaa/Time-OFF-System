using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Time_OFF_System.Models
{
    public class AppUser:IdentityUser
    {
        public string name { get; set; }
        public int salary { get; set; }
        public String Department { get; set; }
        public DateTime HireDate { get; set; }
        public string ImagePath { get; set; }

      //[ForeignKey("ManagerId")]
      //public string ManagerId { get; set; }
      //public AppUser Manager { get; set; }
      //public  ICollection<AppUser> Employees { get; set; }
      public ICollection<Request> Requests{ get; set; } 
       
    }
}
