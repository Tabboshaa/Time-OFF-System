using Time_OFF_System.Data.ViewModels;

namespace Time_OFF_System.Models.Repositories
{
    public interface IAppUserRepository
    {
        public Task login(LoginVM loginVM);
       
    }
}
