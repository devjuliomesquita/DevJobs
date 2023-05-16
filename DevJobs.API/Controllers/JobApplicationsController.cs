using Microsoft.AspNetCore.Mvc;

namespace DevJobs.API.Controllers
{
    [Route("api/JobVacancy/{id}/Applications")]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        
        
        [HttpPost]
        public IActionResult Post(int id)
        {
            //var jobVacancy = _irepository.GetById(id);
            //if(jobVacancy == null) { NotFound(); }

            //var jobApplication = new JobApplication(
            //    model.ApplicatName,
            //    model.ApplicatEmail,
            //    id);
            //_irepository.AddApplication(jobApplication);
            return Ok();
        }
    }
}
