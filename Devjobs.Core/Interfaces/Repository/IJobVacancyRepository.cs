using DevJobs.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Core.Interfaces.Repository
{
    public interface IJobVacancyRepository : IRepositoryBase<JobVacancy>
    {
        JobVacancy GetDetailsVacancy(int id);
    }
}
