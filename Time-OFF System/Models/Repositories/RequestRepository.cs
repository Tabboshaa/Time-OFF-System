using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Time_OFF_System.Data;
using Time_OFF_System.Data.ViewModels;

namespace Time_OFF_System.Models.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly AppDbContext context;
        private  readonly IHttpContextAccessor httpContextAccessor;

        public RequestRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }
     
        public async Task  addRequest(CreateRequestVM requestVM)
        {
            var user = httpContextAccessor.HttpContext?.User;
            var employeeId =user.FindFirst(ClaimTypes.NameIdentifier).Value;

            var request = new Request()
            {
                EmployeeId= employeeId,
                startDate = requestVM.startDate,
                endDate = requestVM.endDate,
                subject = requestVM.subject
            };
            context.Requests.Add(request);
            await context.SaveChangesAsync();

        }

        
    }
}
