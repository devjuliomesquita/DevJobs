
using DevJobs.Application.InputModels;
using DevJobs.Core.Entities;
using DevJobs.Infrastructure.Persistence;
using DevJobs.Infrastructure.Persistence.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevJobs.API.Controllers
{
    [Route("api/JobVacancy/{id}/Applications")]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        private readonly IjobVacancyRepository _irepository;
        public JobApplicationsController(IjobVacancyRepository repository)
        {
            _irepository = repository;
        }
        [HttpPost]
        public IActionResult Post(int id, AddJobApplication model)
        {
            var jobVacancy = _irepository.GetById(id);
            if(jobVacancy == null) { NotFound(); }

            var jobApplication = new JobApplication(
                model.ApplicatName,
                model.ApplicatEmail,
                id);
            _irepository.AddApplication(jobApplication);
            return Ok();
        }
    }
}
