using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Manager"))
            {

            }
            var allRequests = await context.Requests.Include(x => x.Employee).ToListAsync();
            return View(allRequests);
        }

        public IActionResult Create()
         {
             return View();
         }
        [HttpPost]
        public async Task<IActionResult> Create(CreateRequestVM requestVM)
        {
            if (!ModelState.IsValid)
                return View(requestVM);
            var emplyeeid = userManager.GetUserId(User);
            var employee= await userManager.FindByIdAsync(emplyeeid);
            var request = new Request()
            {
                Employee=employee,
                startDate=requestVM.startDate,
                endDate=requestVM.endDate,
                subject=requestVM.subject
            };
            context.Requests.Add(request);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        } 
    }
}
