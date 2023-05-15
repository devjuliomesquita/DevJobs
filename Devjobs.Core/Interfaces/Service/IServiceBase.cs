using DevJobs.Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Core.Interfaces.Service
{
    public interface IServiceBase<TEntity> where TEntity : BaseEntity
    {
        TEntity Add<TInputModel, TOutputModel, TValidator>(TInputModel inputModel) 
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class;
        TEntity Update<TInputModel, TOutputModel, TValidator>(TInputModel inputModel) 
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class;
        void Delete(int id);
        IEnumerable<TOutputModel>GetAll<TOutputModel>() where TOutputModel : class;
        TOutputModel GetById<TOutputModel>(int id) where TOutputModel : class;
    }
}
