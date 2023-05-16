using DevJobs.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Core.Interfaces.Service
{
    public interface IJobVacancyService : IServiceBase<JobVacancy>
    {
        TOutputModel GetDetailsVacancy<TOutputModel>(int id) where TOutputModel : class;
    }
}
