using System;
using System.Collections.Generic;
using System.Text;

namespace SSAApp.Web.Domain.Interfaces.Services
{
    public interface IBaseService<TEntity> where TEntity:class
    {
        TEntity Add(TEntity entity);
        TEntity Modify(TEntity entity);
        TEntity Delete(int id);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Dispose();
    }
}
