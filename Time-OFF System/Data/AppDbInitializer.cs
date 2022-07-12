using eTickets.Data.Static;
using Time_OFF_System.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Time_OFF_System.Data;
using Time_OFF_System.Models;

namespace eTickets.Data
{
    public class AppDbInitializer
    {
      public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Manager))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Manager));
                if (!await roleManager.RoleExistsAsync(UserRoles.Employee))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Employee));

                //User Manager opject for all 
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                //data for first Manager
                string ManagerUserEmail = "azbassiouny_manager1@et3.com";
                string ManagerUserPhoneNumber = "01099881399";
                string ManagerDempartment = "IT Department";
                double Managersalary = 20000;
                string ManagerName = "Azbassiouny";
                DateTime ManagerHireDate = new DateTime(1/1/2011);

                var ManagerUser = await userManager.FindByEmailAsync(ManagerUserEmail);
                if(ManagerUser == null)
                {
                    var newManagerUser = new AppUser()
                    {
                        
                        UserName = "Manager-user1",
                        Email = ManagerUserEmail,
                        PhoneNumber = ManagerUserPhoneNumber,
                        Department=ManagerDempartment,
                        salary=(int)Managersalary,
                        HireDate=ManagerHireDate,
                        name=ManagerName,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true
                    };
                    await userManager.CreateAsync(newManagerUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newManagerUser, UserRoles.Manager);
                }
                //end of first manager

                //manager tow
        
                //end od employee one

                // employee tow 
                string EmployeeEmail2 = "abdalaziz_Employee2@et3.com";
                string EmployeePhoneNumber2 = "01099881399";
                string EmployeeDempartment2 = "HR Department";
                double Employeesalary2 = 8500;
                string EmployeeName2 = "AbdalazizHR";
                DateTime EmployeeHireDate2 = new DateTime(1 / 1 / 2011);


                var EmployeeUser2 = await userManager.FindByEmailAsync(EmployeeEmail2);
                if (EmployeeUser2 == null)
                {
                    var newEmployeeUser2 = new AppUser()
                    {
                       
                        UserName = "Abdalaziz-Employee-user2",
                        Email = EmployeeEmail2,
                        PhoneNumber = EmployeePhoneNumber2,
                        Department = EmployeeDempartment2,
                        salary = (int)Employeesalary2,
                        HireDate = EmployeeHireDate2,
                        name = EmployeeName2,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true
                    };
                    await userManager.CreateAsync(newEmployeeUser2, "Coding@1234?");
                    await userManager.AddToRoleAsync(newEmployeeUser2, UserRoles.Employee);
                }
                //end of employee 2 
            }
        }
    }
}
