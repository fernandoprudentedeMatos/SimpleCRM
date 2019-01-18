using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCRM.Models;
using SimpleCRM.Services;

namespace SimpleCRM.Controllers
{
    [Produces("application/json")]
    [Route("api/Costumers")]
    public class CostumersController : Controller
    {
        private CostumerService service;

        public CostumersController(CostumerService service)
        {
            this.service = service;
        }

        // GET: api/Costumers
        [HttpGet]
        public IEnumerable<CostumerModel> Get()
        {
            return service.GetAll();
        }

        // GET: api/Costumers/search
        [HttpGet("/search")]
        public IEnumerable<CostumerModel> Search()
        {
            //TODO: Fazer Search
            return service.GetAll();
        }

        // GET: api/Costumers/5
        [HttpGet("{id}", Name = "Get")]
        public CostumerModel Get(string id)
        {
            return service.GetById(id);
        }
        
        // POST: api/Costumers
        [HttpPost]
        public void Post([FromBody]CostumerModel value)
        {
            service.Insert(value);
        }
        
        // PUT: api/Costumers/5
        [HttpPut]
        public void Put([FromBody]CostumerModel value)
        {
            service.Update(value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            service.Remove(id);
        }
    }
}
