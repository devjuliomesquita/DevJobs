using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Core.Entities
{
    public class JobApplication
    {
        public JobApplication(string applicatName, string applicantEmail, int idApplicant)
        {
            ApplicatName = applicatName;
            ApplicantEmail = applicantEmail;
            IdApplicant = idApplicant;
        }

        public int Id { get; private set; }
        public string ApplicatName { get; private set; }
        public string ApplicantEmail { get; private set; }
        public int IdApplicant { get; private set; }
    }
}
