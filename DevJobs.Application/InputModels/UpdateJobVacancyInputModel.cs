using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Application.InputModels
{
    public record UpdateJobVacancyInputModel(
        string Title,
        string Description,
        string Company,
        bool IsRemote,
        string SalaryRange)
    {
    }
}
