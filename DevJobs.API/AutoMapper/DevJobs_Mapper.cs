using AutoMapper;
using DevJobs.API.DTO.InputModel;
using DevJobs.API.DTO.ViewModel;
using DevJobs.Core.Entities;

namespace DevJobs.API.AutoMapper
{
    public class DevJobs_Mapper : Profile
    {
        public DevJobs_Mapper()
        {
            //Mapeamento da viewmodel para a entidade
            CreateMap<JobVacancyInputModel, JobVacancy>();
            CreateMap<JobVacancyUpdateInputModel, JobVacancy>();
            CreateMap<JobApplicationInputModel, JobApplication>();

            //Mepeamento da entidade para a viewmodel
            CreateMap<JobVacancy, JobVacancyViewModel>();
            CreateMap<JobVacancy, JobVacancyDetailsViewModel>();
            CreateMap<JobApplication, JobApplicationViewModel>();
            CreateMap<JobVacancy, JobVacancyApplicationViewModel>();
        }
    }
}
