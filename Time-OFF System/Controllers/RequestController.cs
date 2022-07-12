using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Time_OFF_System.Data;
using Time_OFF_System.Data.ViewModels;
using Time_OFF_System.Models;

namespace Time_OFF_System.Controllers
{
    public class RequestController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly AppDbContext context;

        public RequestController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AppDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
        }

        public IActionResult Index( RequestVM requestVM)
        {
            return View(requestVM);
        }
        
    }
}
