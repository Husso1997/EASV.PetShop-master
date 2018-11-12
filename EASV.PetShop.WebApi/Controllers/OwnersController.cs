using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Easv.PetShop.Core.Application.Services.ApplicationService.Services;
using Easv.PetShop.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EASV.PetShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        IOwnerService ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            this.ownerService = ownerService;
          
        }
        // GET: api/Owner
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IEnumerable<Owner> Get()
        {
            return ownerService.GetAllOwners();
        }

        // GET: api/Owner/5
        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}", Name = "Get")]
        public Owner Get(int id)
        {
           return ownerService.GetOwnerById(id);
        }

        // POST: api/Owner
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public void Post([FromBody] Owner value)
        {
            ownerService.CreateOwner(value);
        }

        // PUT: api/Owner/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Owner value)
        {
            value.Id = id;
            ownerService.UpdateOwner(value);
        }

        // DELETE: api/ApiWithActions/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ownerService.DeleteOwner(id);
        }
    }
}
