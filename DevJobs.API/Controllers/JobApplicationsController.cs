﻿using DevJobs.API.DTO.InputModel;
using DevJobs.API.DTO.ViewModel;
using DevJobs.Application.Validators;
using DevJobs.Core.Entities;
using DevJobs.Core.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace DevJobs.API.Controllers
{
    [Route("api/JobVacancy/{id}/Applications")]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        private readonly IJobApplicationService _jobApplicationService;
        private readonly IServiceBase<JobVacancy> _serviceBase;
        public JobApplicationsController(IJobApplicationService jobApplicationService, IServiceBase<JobVacancy> serviceBase)
        {
            _jobApplicationService = jobApplicationService;
            _serviceBase = serviceBase;
        }

        [HttpPost("{id}")]
        public IActionResult Post([FromBody] int id, JobApplicationInputModel inputModel)
        {
            var jobVacancy = _serviceBase.GetById<JobVacancy>(id);
            if (jobVacancy == null) { return NotFound(); }
            return 
                Excute(() => _jobApplicationService
                .AddJobApplication<JobApplicationInputModel, JobApplicationViewModel, JobApplicationValidator>
                (inputModel));
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
