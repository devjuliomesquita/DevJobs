using AutoMapper;
using DevJobs.Core.Entities;
using DevJobs.Core.Interfaces.Repository;
using DevJobs.Core.Interfaces.Service;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Application.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : BaseEntity
    {
        //CONSTRUTORES
        private readonly IRepositoryBase<TEntity> _repositoryBase;
        private readonly IMapper _mapper;
        public ServiceBase(IRepositoryBase<TEntity> repositoryBase, IMapper mapper)
        {
            _repositoryBase = repositoryBase;
            _mapper = mapper;
        }
        public TOutputModel Add<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<TEntity>
        {
            TEntity entity = _mapper.Map<TEntity>(inputModel); //Mapeando os dados da inputModel para uma variável
            Validate(entity, Activator.CreateInstance<TValidator>());//Validando os dados
            _repositoryBase.Add(entity);//Adicionando os dados via repositório
            TOutputModel outputModel = _mapper.Map<TOutputModel>(entity);//Mapeando a saída dos dados
            return outputModel;
        }

        public void Delete(int id) => _repositoryBase.Delete(id);
        

        public IEnumerable<TOutputModel> GetAll<TOutputModel>() where TOutputModel : class
        {
            var entities = _repositoryBase.GetAll().ToList();
            var outputModel = entities.Select(e => _mapper.Map<TOutputModel>(e));
            return outputModel;
        }

        public TOutputModel GetById<TOutputModel>(int id) where TOutputModel : class
        {
            var entity = _repositoryBase.GetById(id);
            var outputModel = _mapper.Map<TOutputModel>(entity);
            return outputModel;
        }

        public TOutputModel Update<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<TEntity>
        {
            var entity = _mapper.Map<TEntity>(inputModel);
            Validate(entity, Activator.CreateInstance<TValidator>());
            _repositoryBase.Update(entity);
            TOutputModel outputModel = _mapper.Map<TOutputModel>(entity);
            return outputModel;
        }

        //Validação
        private void Validate(TEntity entity, AbstractValidator<TEntity> validator)
        {
            if (entity == null)
            {
                throw new Exception("Registro não encontrado.");
            }
            validator.ValidateAndThrow(entity);
        }
    }
}
