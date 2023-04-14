using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Application.InputModels
{
    public record AddJobApplication(
        string ApplicatName,
        string ApplicatEmail,
        int IdApplicant)
    {
    }
}
