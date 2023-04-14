using DevJobs.Core.Entities;
using DevJobs.Application.InputModels;
using DevJobs.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevJobs.Infrastructure.Persistence.Repositories.Interfaces;

namespace DevJobs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobVacancyController : Controller
    {
        private readonly IjobVacancyRepository _repository;
        public JobVacancyController(IjobVacancyRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var jobVacancies = _repository.GetAll();
            return Ok(jobVacancies);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var jobVacancy = _repository.GetById(id);
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
            _repository.Add(jobVacancy);
            return CreatedAtAction("GetById", new {id = jobVacancy.Id}, jobVacancy);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateJobVacancyInputModel model)
        {
            var jobVacancy = _repository.GetById(id);
            if (jobVacancy == null) { return NotFound(); }
            jobVacancy.Update(
                model.Title,
                model.Description,
                model.Company,
                model.IsRemote,
                model.SalaryRange);
            _repository.Update(jobVacancy);
            return Ok();
        }
    }
}
