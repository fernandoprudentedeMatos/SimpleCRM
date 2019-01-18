using SimpleCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SimpleCRM.Repositories
{
    public interface IRepository<TModel>
        where TModel: class, IModel
    {
        void Insert(TModel entity);
        void Delete(TModel entity);
        IQueryable<TModel> SearchFor(Expression<Func<TModel, bool>> predicate);
        IQueryable<TModel> GetAll();
        void Update(TModel entity);
        TModel GetById(params object[] keys);
    }
}
