using System;
using System.Collections.Generic;
using System.Text;
using SSAApp.Web.Domain.Interfaces.Repositories;
using SSAApp.Web.Domain.Interfaces.Services;

namespace SSAApp.Web.Domain.Core
{
    public class BaseService<TEntity> : IDisposable, IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public TEntity Add(TEntity entity)
        {
            return baseRepository.Add(entity);
        }

        public TEntity Delete(int id)
        {
            return baseRepository.Delete(id);
        }

        public TEntity GetById(int id)
        {
            return baseRepository.GetById(id);
        }

        public TEntity Modify(TEntity entity)
        {
            return baseRepository.Modify(entity);
        }

        public void Dispose()
        {
            baseRepository.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return baseRepository.GetAll();
        }
    }
}
