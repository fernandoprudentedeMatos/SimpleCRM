using SimpleCRM.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using SimpleCRM.Models;
using System.Linq;
using System.Linq.Expressions;
using SimpleCRM.Services;
using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace SimpleCRM.Test.Services
{


    public class CostumerRepositoryStub : ICostumerRepository
    {
        public void Delete(CostumerModel entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CostumerModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public CostumerModel GetById(params object[] keys)
        {
            return null;
        }

        public void Insert(CostumerModel entity)
        {
            if (entity.Email.Length > 70)
                throw new DbUpdateException("Erro", new Exception());
        }

        public IQueryable<CostumerModel> SearchFor(Expression<Func<CostumerModel, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(CostumerModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
