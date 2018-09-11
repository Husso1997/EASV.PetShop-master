using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Easv.PetShop.Core.Application.Services.ApplicationService;
using Easv.PetShop.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EASV.PetShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IPetService petService;
        public ValuesController(IPetService petService)
        {
            this.petService = petService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return petService.GetAllPets().ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            return petService.GetPetByID(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Pet value)
        {
            petService.CreatePet(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Pet value)
        {
            value.PetID = id;
            petService.UpdatePet(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            petService.DeletePet(id);
        }
    }
}
