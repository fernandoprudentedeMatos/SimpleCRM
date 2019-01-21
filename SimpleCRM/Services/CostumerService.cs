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
            this.ValidateModel(model);

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
            this.ValidateModel(model);

            model.Id = null;
            model.DateCreated = DateTime.Now;

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

        private void ValidateModel(CostumerModel model)
        {
            if (model == null)
                throw new InvalidServiceRequestException("Cliente deve ser informado.");

            if (string.IsNullOrWhiteSpace(model.Nome))
                throw new InvalidServiceRequestException("Nome de cliente deve ser informado");

            if (string.IsNullOrWhiteSpace(model.Email))
                throw new InvalidServiceRequestException("Email de cliente deve ser informado");
        }
    }
}
