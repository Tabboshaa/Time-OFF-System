using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Time_OFF_System.Data.ViewModels
{
    public class CreateRequestVM
    {
       [DataType(DataType.MultilineText)]
        [Display(Name = "Subject")]
        public string subject { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.DateTime)]
        public DateTime? startDate { get; set; }
        
        [Display(Name = "End Date")]
        [DataType(DataType.DateTime)]
        public DateTime? endDate { get; set; }

    }
}
