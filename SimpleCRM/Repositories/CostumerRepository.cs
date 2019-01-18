using SimpleCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCRM.Repositories
{
    public class CostumerRepository: RepositoryBase<CostumerModel>, ICostumerRepository
    {
        public CostumerRepository(CRMDbContext context) : base(context)
        {

        }
    }
}
