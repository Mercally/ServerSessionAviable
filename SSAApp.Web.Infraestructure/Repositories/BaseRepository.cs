using SSAApp.Web.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SSAApp.Web.Infraestructure.Repositories
{
    public class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {
        public TEntity Add(TEntity entity)
        {
            using (var context = new ssaappContext())
            {
                context.Entry(entity).State = EntityState.Added;
                context.SaveChanges();
                return entity;
            }
        }

        public TEntity Delete(int id)
        {
            using (var context = new ssaappContext())
            {
                var entity = context.Server.FirstOrDefaultAsync(x => x.IdServer == id).Result;
                if (entity != null)
                {
                    context.Entry(entity).State = EntityState.Deleted;
                    context.SaveChanges();
                }
                return entity as TEntity;
            }
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            using (var context = new ssaappContext())
            {
                var entity = context.Server.ToListAsync().Result;
                return entity as IEnumerable<TEntity>;
            }
        }

        public TEntity GetById(int id)
        {
            using (var context = new ssaappContext())
            {
                var entity = context.Server.FirstAsync(x => x.IdServer == id).Result;
                return entity as TEntity;
            }
        }

        public TEntity Modify(TEntity entity)
        {
            using (var context = new ssaappContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
        }
    }
}
