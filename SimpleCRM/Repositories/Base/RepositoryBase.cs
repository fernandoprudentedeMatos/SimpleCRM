using Microsoft.EntityFrameworkCore;
using SimpleCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCRM.Repositories
{
    public class RepositoryBase<TModel> : IRepository<TModel>
        where TModel : class, IModel
    {
        DbContext dbContext;

        public RepositoryBase(DbContext bankDbContext)
        {
            this.dbContext = bankDbContext;
            DbSet = dbContext.Set<TModel>();
        }

        private void DetachIfExist(TModel entity)
        {
            var entityAtachedWithSomeKey = DbSet.Local.FirstOrDefault(item => item.Id.Equals(entity.Id));

            if (entityAtachedWithSomeKey != null)
                dbContext.Entry(entityAtachedWithSomeKey).State = EntityState.Detached;
        }

        private DbSet<TModel> DbSet;

        public DbSet<TModel> GetDbSet()
        {
            return DbSet;
        }

        public virtual void Insert(TModel entity)
        {
            DbSet.Add(entity);
            dbContext.SaveChanges();
        }

        public virtual void Delete(TModel entity)
        {
            DbSet.Remove(entity);
            dbContext.SaveChanges();
        }

        public virtual void Update(TModel entity)
        {

            DetachIfExist(entity);

            DbSet.Attach(entity);

            dbContext.Entry(entity).State = EntityState.Modified;

            dbContext.SaveChanges();

            DetachIfExist(entity);
        }

        public IQueryable<TModel> SearchFor(System.Linq.Expressions.Expression<Func<TModel, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual IQueryable<TModel> GetAll()
        {
            return DbSet;
        }

        public TModel GetById(params object[] keys)
        {
            return DbSet.Find(keys);
        }
    }
}
