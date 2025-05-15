using System.ComponentModel.DataAnnotations;
using PDI.Models;

namespace PDI.DTO
{
    public class Interview
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string? HrName { get; set; }

        public string? HrEmail { get; set; }

        public string? Position { get; set; }

        public DateTime InterviewDate { get; set; }

        public string Status { get; set; }

        public string? Notes { get; set; }
    }
   public class interviewCreateDto()
    {
        [Required]
        public string CompanyName { get; set; }

        public string? HrName { get; set; }

        public string? HrEmail { get; set; }

        public string? Position { get; set; }

        [Required]
        public DateTime InterviewDate { get; set; }

        public status Status { get; set; } = status.pending;

        public string? Notes { get; set; }
    }
    public class interviewUpdateDto() 
    {
        public string? CompanyName { get; set; }

        public string? HrName { get; set; }

        public string? HrEmail { get; set; }

        public string? Position { get; set; }

        public DateTime? InterviewDate { get; set; }

        public status? Status { get; set; }

        public string? Notes { get; set; }
    }
}
