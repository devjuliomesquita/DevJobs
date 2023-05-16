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
    public class JobVacancyService : ServiceBase<JobVacancy>, IJobVacancyService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<JobVacancy> _repositoryBase;
        private readonly IJobVacancyRepository _jobVacancyRepository;
        public JobVacancyService(
            IMapper mapper, 
            IRepositoryBase<JobVacancy> repositoryBase,
            IJobVacancyRepository jobVacancyRepository) : base(repositoryBase, mapper)
        {
            _mapper = mapper;
            _repositoryBase = repositoryBase;
            _jobVacancyRepository = jobVacancyRepository;
        }
        public TOutputModel GetDetailsVacancy<TOutputModel>(int id) where TOutputModel : class
        {
            var entity = _jobVacancyRepository.GetDetailsVacancy(id);
            TOutputModel outputModel = _mapper.Map<TOutputModel>(entity);
            return outputModel;
        }

        //Validação
        private void Validate(JobVacancy vacancy, AbstractValidator<JobVacancy> validator)
        {
            if (vacancy == null)
            {
                throw new Exception("Registro não encontrado.");
            }
            validator.ValidateAndThrow(vacancy);
        }
    }
}
