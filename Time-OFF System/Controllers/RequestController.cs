using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Time_OFF_System.Data;
using Time_OFF_System.Data.ViewModels;
using Time_OFF_System.Models;
using Time_OFF_System.Models.Repositories;

namespace Time_OFF_System.Controllers
{
    public class RequestController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly AppDbContext context;
        private readonly IRequestRepository requestRepository;

        public RequestController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AppDbContext context, IRequestRepository requestRepository )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
            this.requestRepository = requestRepository;
        }

        public async Task<IActionResult> Index()
        {
            var Requests = new List<Request>();
            if (User.IsInRole("Manager"))
            {
                // get requests where employee.managerId=user.id 

                Requests = await context.Requests.AsQueryable()
                    .Include(x => x.Employee)
                    .ToListAsync();
            }
            else if(User.IsInRole("Employee"))
            {
                var userId=userManager.GetUserId(User);
                  Requests = await context.Requests.AsQueryable()
                    .Include(x => x.Employee)
                    .Where(x => x.EmployeeId.Equals(userId))
                    .ToListAsync();
            }
            var response = new IndexRequestsVM()
            {
                Rejected = Requests.Where(x => x.status == -1).ToList(),
                Accepted = Requests.Where(x => x.status == 1).ToList(),
                Binding = Requests.Where(x => x.status == 0).ToList()
            };
            return View(response);
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

            await requestRepository.addRequest(requestVM);

            return RedirectToAction(nameof(Index));
        } 

        public async Task<IActionResult> UpdateStatus(int Id , int status)
        {
            var request = await context.Requests.FirstOrDefaultAsync(x=>x.id==Id);
            if (request!=null)
            {
                request.status=status;
                context.Entry(request).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("home", "Error");
            }
    
        }
    }
}
