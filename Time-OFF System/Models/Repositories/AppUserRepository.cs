using Microsoft.AspNetCore.Identity;
using Time_OFF_System.Data;
using Time_OFF_System.Data.ViewModels;

namespace Time_OFF_System.Models.Repositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly AppDbContext context;

        public AppUserRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AppDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
        }

        public Task login(LoginVM loginVM)
        {
            throw new NotImplementedException();
        }

        //public async Task<AppuserVM> Login(LoginVM loginVM)
        //{
        //    var user = await userManager.FindByEmailAsync(loginVM.Email);

        //    if (user != null)
        //    {
        //        var passwordCheck = await userManager.CheckPasswordAsync(user, loginVM.password);
        //        if (passwordCheck == true)
        //        {
        //            var result = await signInManager.PasswordSignInAsync(user, loginVM.password, false, false);
        //            if (result.Succeeded)
        //            {

        //                var AppUserVM = new AppuserVM()
        //                {
        //                    name = user.name,
        //                    Department = user.Department,
        //                    salary = user.salary,
        //                    email = user.Email,
        //                    HireDate = user.HireDate,
        //                    PhoneNumber = user.PhoneNumber,
        //                    imagePath = user.ImagePath
        //                };
        //                return AppUserVM;
        //            }
        //        }
        //    }

        //    return AppUserVM;
        //}

    }
}
