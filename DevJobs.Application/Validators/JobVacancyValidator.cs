using DevJobs.Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Application.Validators
{
    public class JobVacancyValidator : AbstractValidator<JobVacancy>
    {
        public JobVacancyValidator()
        {
            RuleFor(jv => jv.Title)
                .NotEmpty().WithMessage("Por favor entre com um título.")
                .NotNull().WithMessage("Por favor entre com um título.")
                .MaximumLength(100).WithMessage("Título pode conter no máximo 100 caracteres.")
                .MinimumLength(3).WithMessage("Título deve conter no mínimo 3 caractes.");
            RuleFor(jv => jv.Description)
                .NotEmpty().WithMessage("Por favor entre com um descrição.")
                .NotNull().WithMessage("Por favor entre com um descrição.")
                .MaximumLength(300).WithMessage("A descrição pode conter no máximo 300 caracteres.")
                .MinimumLength(3).WithMessage("A descrição deve conter no mínimo 3 caractes.");
            RuleFor(jv => jv.Company)
                .NotEmpty().WithMessage("Por favor entre com um companhia.")
                .NotNull().WithMessage("Por favor entre com um companhia.")
                .MaximumLength(100).WithMessage("Nome da companhia pode conter no máximo 150 caracteres.")
                .MinimumLength(3).WithMessage("Nome da companhia deve conter no mínimo 3 caractes.");
            //RuleFor(jv => jv.IsRemote)
            //    .NotEmpty().WithMessage("Por favor entre com um range salarial.")
            //    .NotNull().WithMessage("Por favor entre com um range salarial.");
                
            RuleFor(jv => jv.SalaryRange)
                .NotEmpty().WithMessage("Por favor entre com um range salarial.")
                .NotNull().WithMessage("Por favor entre com um range salarial.")
                .MaximumLength(50).WithMessage("O range salarial pode conter no máximo 50 caracteres.")
                .MinimumLength(4).WithMessage("O range salarial deve conter no mínimo 4 caractes.");
        }
    }
}
