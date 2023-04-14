
using DevJobs.Application.InputModels;
using DevJobs.Core.Entities;
using DevJobs.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevJobs.API.Controllers
{
    [Route("api/JobVacancy/{id}/Applications")]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        private readonly DevJobsContext _context;
        public JobApplicationsController(DevJobsContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Post(int id, AddJobApplication model)
        {
            var jobVacancy = _context.JobVacancies.SingleOrDefault(jv => jv.Id == id);
            if(jobVacancy == null) { NotFound(); }

            var jobApplication = new JobApplication(
                model.ApplicatName,
                model.ApplicatEmail,
                id);
            jobVacancy!.Applications.Add(jobApplication);
            return Ok();
        }
    }
}
