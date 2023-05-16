using AutoMapper;
using DevJobs.Core.Entities;
using DevJobs.Core.Interfaces.Repository;
using DevJobs.Core.Interfaces.Service;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Application.Services
{
    public class JobApplicationService : ServiceBase<JobApplication>, IJobApplicationService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<JobApplication> _repositoryBase;
        public JobApplicationService(
            IRepositoryBase<JobApplication> repositoryBase, 
            IMapper mapper) : base(repositoryBase, mapper)
        {
            _mapper = mapper;
            _repositoryBase = repositoryBase;
        }

        public TOutputModel AddJobApplication<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<JobApplication>
        {
            var application = _mapper.Map<JobApplication>(inputModel);
            Validate(application, Activator.CreateInstance<TValidator>());
            _repositoryBase.Add(application);
            TOutputModel outputModel = _mapper.Map<TOutputModel>(application);
            return outputModel;
            
        }

        //Validação
        private void Validate(JobApplication application, AbstractValidator<JobApplication> validator)
        {
            if (application == null)
            {
                throw new Exception("Registro não encontrado.");
            }
            validator.ValidateAndThrow(application);
        }
    }
}
