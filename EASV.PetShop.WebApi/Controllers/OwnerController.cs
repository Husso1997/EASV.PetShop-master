using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Easv.PetShop.Core.Application.Services.ApplicationService.Services;
using Easv.PetShop.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EASV.PetShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        IOwnerService ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            this.ownerService = ownerService;
          
        }
        // GET: api/Owner
        [HttpGet]
        public IEnumerable<Owner> Get()
        {
            return ownerService.GetAllOwners();
        }

        // GET: api/Owner/5
        [HttpGet("{id}", Name = "Get")]
        public Owner Get(int id)
        {
           return ownerService.GetOwnerById(id);
        }

        // POST: api/Owner
        [HttpPost]
        public void Post([FromBody] Owner value)
        {
            ownerService.CreateOwner(value);
        }

        // PUT: api/Owner/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Owner value)
        {
            value.Id = id;
            ownerService.UpdateOwner(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ownerService.DeleteOwner(id);
        }
    }
}
