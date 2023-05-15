using DevJobs.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Core.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IList<TEntity> GetAll();
        TEntity GetById(int id);
    }
}
