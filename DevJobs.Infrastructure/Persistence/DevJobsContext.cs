using Devjobs.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Infrastructure.Persistence
{
    public class DevJobsContext
    {
        public DevJobsContext()
        {
            JobVacancies = new List<JobVacancy>();
        }
        public List<JobVacancy> JobVacancies { get; set; }
    }
}
