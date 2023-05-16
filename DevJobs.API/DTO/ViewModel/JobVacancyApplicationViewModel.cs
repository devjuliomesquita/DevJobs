namespace DevJobs.API.DTO.ViewModel
{
    public class JobVacancyApplicationViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Company { get; set; }
        public bool IsRemote { get; set; }
        public string? SalaryRange { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<JobApplicationViewModel>? Applications { get; set; }
    }
}
