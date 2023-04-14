using DevJobs.Core.Entities;
using DevJobs.Application.InputModels;
using DevJobs.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevJobs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobVacancyController : Controller
    {
        private readonly DevJobsContext _context;
        public JobVacancyController(DevJobsContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var jobVacancies = _context.JobVacancies;
            return Ok(jobVacancies);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var jobVacancy = _context.JobVacancies.SingleOrDefault(jv => jv.Id == id);
            if(jobVacancy == null) { return NotFound(); }


            return Ok(jobVacancy);
        }
        [HttpPost]
        public IActionResult Post(AddJobVacancyInputModel model)
        {
            var jobVacancy = new JobVacancy(
                model.Title,
                model.Description,
                model.Company,
                model.IsRemote,
                model.SalaryRange
                );
            _context.JobVacancies.Add(jobVacancy);
            return CreatedAtAction("GetById", new {id = jobVacancy.Id}, jobVacancy);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateJobVacancyInputModel model)
        {
            var jobVacancy = _context.JobVacancies.SingleOrDefault(jv => jv.Id == id);
            if (jobVacancy == null) { return NotFound(); }
            jobVacancy.Update(
                model.Title,
                model.Description,
                model.Company,
                model.IsRemote,
                model.SalaryRange);
            return Ok();
        }
    }
}
