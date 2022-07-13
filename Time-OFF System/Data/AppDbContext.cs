using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Time_OFF_System.Models;

namespace Time_OFF_System.Data
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Request> Requests { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<AppUser>()
        //                .HasOne(x => x.Manager)
        //                .WithMany(x => x.Employees)
        //                .HasForeignKey(x => x.ManagerId);
        //}


    }
}
