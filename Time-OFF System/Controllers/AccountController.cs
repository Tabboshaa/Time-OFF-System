using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Time_OFF_System.Data;
using Time_OFF_System.Data.ViewModels;
using Time_OFF_System.Models;

namespace Time_OFF_System.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly AppDbContext context;

        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            AppDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
        }

        public IActionResult profile(AppuserVM appuserVM)
        {
            return View(appuserVM);
        }
        public IActionResult Login() => View(new LoginVM());

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
             if(! ModelState.IsValid) return View(loginVM);

            var user = await userManager.FindByEmailAsync(loginVM.Email);

            if(user != null)
            {
                var passwordCheck =await userManager.CheckPasswordAsync(user,loginVM.password);
                if(passwordCheck == true)
                {
                    var result = await signInManager.PasswordSignInAsync(user,loginVM.password,false,false);
                    if(result.Succeeded)
                    {

                        var AppUserVM = new AppuserVM()
                        {
                         name=user.name,
                         Department=user.Department,
                         salary=user.salary,
                         email=user.Email,
                         HireDate=user.HireDate,
                         PhoneNumber=user.PhoneNumber,
                         imagePath=user.ImagePath
                        };
                        return RedirectToAction(nameof(profile),AppUserVM);
                    }
                    TempData["Erorr"] = "Wrong Password ";
                    return View(loginVM);
                }
            }
            TempData["Erorr"] = "User is Invalid Try Again ! ";
            return View(loginVM);

            
        }

        
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
        
    }
}
