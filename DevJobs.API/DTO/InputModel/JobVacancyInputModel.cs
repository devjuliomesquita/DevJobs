using DevJobs.Core.Entities;

namespace DevJobs.API.DTO.InputModel
{
    public class JobVacancyInputModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Company { get; set; }
        public bool IsRemote { get; set; }
        public string? SalaryRange { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        //public List<JobApplicationInputModel>? Applications { get; set; } = new List<JobApplicationInputModel>();
    }
}
