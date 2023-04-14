using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Core.Entities
{
    public class JobApplication
    {
        public JobApplication(string applicatName, string applicantEmail, int idJobVacancy)
        {
            ApplicatName = applicatName;
            ApplicantEmail = applicantEmail;
            IdJobVacancy = idJobVacancy;
        }

        public int Id { get; private set; }
        public string ApplicatName { get; private set; }
        public string ApplicantEmail { get; private set; }
        public int IdJobVacancy { get; private set; }
    }
}
