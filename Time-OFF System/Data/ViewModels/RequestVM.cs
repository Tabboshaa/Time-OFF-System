namespace Time_OFF_System.Data.ViewModels
{
    public class RequestVM
    {
        public int id { get; set; }
        public string subject { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public int status { get; set; }
        public int EmployeeId { get; set; }
    }
}
