using DevJobs.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Infrastructure.Persistence.Repositories.Interfaces
{
    public interface IjobVacancyRepository
    {
        List<JobVacancy> GetAll();
        JobVacancy GetById(int id);
        void Add(JobVacancy jobVacancy);
        void Update(JobVacancy jobVacancy);
        void AddApplication(JobApplication jobApplication);
        
    }
}
