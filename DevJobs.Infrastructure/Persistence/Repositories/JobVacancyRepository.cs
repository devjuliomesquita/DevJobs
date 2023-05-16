using DevJobs.Core.Entities;
using DevJobs.Core.Interfaces.Repository;
using DevJobs.Infrastructure.Persistence.Context;
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

        public void AddApplication(JobApplication jobApplication)
        {
            _context.Set<JobApplication>().Add(jobApplication);
            _context.SaveChanges();
        }
    }
}
