using SSAApp.Web.Domain.Interfaces.Services;
using SSAApp.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSAApp.Web.Services
{
    public class BaseAppService<TEntity> : IDisposable, IBaseAppService<TEntity> where TEntity : class
    {
        private readonly IBaseService<TEntity> baseService;

        public BaseAppService(IBaseService<TEntity> baseService)
        {
            this.baseService = baseService;
        }

        public TEntity Add(TEntity entity)
        {
            return baseService.Add(entity);
        }

        public TEntity Delete(int id)
        {
            return baseService.Delete(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return baseService.GetAll();
        }

        public TEntity GetById(int id)
        {
            return baseService.GetById(id);
        }

        public TEntity Modify(TEntity entity)
        {
            return baseService.Modify(entity);
        }

        public void Dispose()
        {
            baseService.Dispose();
        }
    }
}
