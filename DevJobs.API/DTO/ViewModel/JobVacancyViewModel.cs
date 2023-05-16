using DevJobs.Core.Entities;

namespace DevJobs.API.DTO.ViewModel
{
    public class JobVacancyViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Company { get; set; }
        public bool IsRemote { get; set; }
    }
}
