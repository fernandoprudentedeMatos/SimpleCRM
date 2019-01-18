using SimpleCRM.Models;
using SimpleCRM.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCRM.Services
{
    public class CostumerService
    {
        private ICostumerRepository repository;

        public CostumerService(ICostumerRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<CostumerModel> GetAll()
        {
            return repository.GetAll();
        }

        public CostumerModel GetById(string id)
        {
            return repository.GetById(id);
        }

        public void Update(CostumerModel model)
        {
            try
            {
                repository.Update(model);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                //--TODO: Usar Entity validate
                throw new InvalidServiceRequestException("Algo deu errado. Verifique se informações e números de caracteres estão corretos.");
            }

        }

        public void Insert(CostumerModel model)
        {
            model.Id = null;

            if (repository.GetAll().Any(c => c.Nome.Equals(model.Nome)))
                throw new InvalidServiceRequestException("Já existe um cliente com o nome informado.");

            try
            {
                repository.Insert(model);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                //--TODO: Usar Entity validate
                throw new InvalidServiceRequestException("Algo deu errado. Verifique se informações e números de caracteres estão corretos.");
            }            
        }

        public void Remove(string id)
        {
            var costumer = GetById(id);

            if (costumer == null)
                throw new InvalidServiceRequestException("Cliente inexistente para exclusão.");

            repository.Delete(costumer);
        }
    }
}
