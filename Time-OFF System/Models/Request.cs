namespace Time_OFF_System.Models
{
    public class Request
    {
        public int id { get; set; }
        public string subject { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public int status { get; set; }
        public AppUser Employee { get; set; }
    }
}
