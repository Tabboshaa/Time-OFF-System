using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Time_OFF_System.Models;

namespace Time_OFF_System.Data
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {

    }
}
