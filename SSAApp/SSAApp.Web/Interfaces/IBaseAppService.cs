using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSAApp.Web.Interfaces
{
    public interface IBaseAppService<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);
        TEntity Modify(TEntity entity);
        TEntity Delete(int id);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Dispose();
    }
}
