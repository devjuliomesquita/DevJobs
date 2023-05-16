using AutoMapper;
using DevJobs.API.DTO.InputModel;
using DevJobs.API.DTO.ViewModel;
using DevJobs.Application.Validators;
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
        private readonly IJobVacancyService _jobVacancyService;
        public JobVacancyController(IServiceBase<JobVacancy> service, IJobVacancyService jobVacancyService)
        {
            _service = service;
            _jobVacancyService = jobVacancyService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return
                Excute(() => _service.GetAll<JobVacancyViewModel>());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if(id == 0) { return NotFound(); }
            return
                Excute(() => _service.GetById<JobVacancyDetailsViewModel>(id));
        }
        [HttpGet("{id}")]
        public IActionResult GetDetails(int id)
        {
            if (id == 0) { return NotFound(); }
            return
                Excute(() => _jobVacancyService.GetDetailsVacancy<JobVacancyApplicationViewModel>(id));
        }
        [HttpPost]
        public IActionResult Post([FromBody] JobVacancyInputModel inputModel)
        {
            if (inputModel == null) {  return NotFound(); }
            return
                Excute(() => _service.Add<JobVacancyInputModel, JobVacancyViewModel, JobVacancyValidator>(inputModel));
        }
        [HttpPut]
        public IActionResult Put(JobVacancyUpdateInputModel inputModel)
        {
            if (inputModel == null) { return NotFound(); }
            return
                Excute(() => _service.Update<JobVacancyUpdateInputModel, JobVacancyViewModel, JobVacancyValidator>(inputModel));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0) { return NotFound(); }
            Excute(() =>
            {
                _service.Delete(id);
                return true;
            });
            return new ContentResult();
        }

        //Criando método de execução
        private IActionResult Excute(Func<object> func)
        {
            try
            {
                var result = func();
                return Ok(result);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex);
            }
        }
    }
}
