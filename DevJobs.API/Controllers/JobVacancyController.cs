using AutoMapper;
using DevJobs.Core.Entities;
using DevJobs.Core.Interfaces.Service;
using DevJobs.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevJobs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobVacancyController : Controller
    {
        //CONSTRUTOR
        private readonly IServiceBase<JobVacancy> _service;
        public JobVacancyController(IServiceBase<JobVacancy> service)
        {
            _service = service;
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
            //var jobVacancy = new JobVacancy(
            //    model.Title,
            //    model.Description,
            //    model.Company,
            //    model.IsRemote,
            //    model.SalaryRange
            //    );
            //_repository.Add(jobVacancy);
            //return CreatedAtAction("GetById", new {id = jobVacancy.Id}, jobVacancy);
            return Ok();
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
