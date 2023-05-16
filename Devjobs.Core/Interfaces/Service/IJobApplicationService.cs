using DevJobs.Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Core.Interfaces.Service
{
    public interface IJobApplicationService : IServiceBase<JobApplication>
    {
        TOutputModel AddJobApplication<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<JobApplication>
            where TInputModel : class
            where TOutputModel : class;
    }
}
