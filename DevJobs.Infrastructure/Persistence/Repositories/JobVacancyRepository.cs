using DevJobs.Core.Entities;
using DevJobs.Core.Interfaces.Repository;
using DevJobs.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Infrastructure.Persistence.Repositories
{
    public class JobVacancyRepository : RepositoryBase<JobVacancy>, IJobVacancyRepository
    {
        private readonly DevJobsContext _context;
        public JobVacancyRepository(DevJobsContext context) : base(context)
        {
            _context = context;
        }

        public JobVacancy GetDetailsVacancy(int id)
        {
            return
                _context.JobVacancies
                .Include(jv => jv.Applications)
                .Where(jv => jv.Id == id)
                .FirstOrDefault();
        }
    }
}
