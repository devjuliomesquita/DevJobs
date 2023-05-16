
using DevJobs.Core.Entities;
using FluentValidation;


namespace DevJobs.Application.Validators
{
    public class JobApplicationValidator : AbstractValidator<JobApplication>
    {
        public JobApplicationValidator()
        {
            RuleFor(ja => ja.ApplicatName)
                .NotEmpty().WithMessage("Por favor entre com um nome.")
                .NotNull().WithMessage("Por favor entre com um nome.")
                .MaximumLength(150).WithMessage("Nome pode conter no máximo 150 caracteres.")
                .MinimumLength(3).WithMessage("Nome deve conter no mínimo 3 caractes.");
            RuleFor(ja => ja.ApplicantEmail)
                .NotEmpty().WithMessage("Por favor entre com um e-mail.")
                .NotNull().WithMessage("Por favor entre com um e-mail.")
                .MaximumLength(100).WithMessage("E-mail pode conter no máximo 100 caracteres.")
                .EmailAddress().WithMessage("Por favor digite um e-mail válido.");


        }
    }
}
