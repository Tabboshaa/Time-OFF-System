using Time_OFF_System.Models;

namespace Time_OFF_System.Data.ViewModels
{
    public class IndexRequestsVM
    {
        public List<Request> Rejected { get; set; }
        public List<Request> Accepted { get; set; }
        public List<Request> Binding { get; set; }


    }
}
