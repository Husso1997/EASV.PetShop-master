using System;
using System.Collections.Generic;
using System.Text;
using Easv.PetShop.Core.Application.Services.DomainService;
using Easv.PetShop.Core.Entities;

namespace Easv.PetShop.Core.Application.Services.ApplicationService.Services
{
    public class OwnerService : IOwnerService
    {
        private IOwnerRepository ownerRepository;
        private IPetService petService;

       public OwnerService(IOwnerRepository ownerRepository, IPetService petService)
        {
            this.ownerRepository = ownerRepository;
            this.petService = petService;
        }

        public List<Pet> GetOwnerPets(int id)
        {
            Owner owner = ownerRepository.GetOwnerById(id);
            return owner.Pets;
        }

        public void CreateOwner(Owner owner)
        {
            ownerRepository.CreateOwner(owner);
        }

        public void DeleteOwner(int id)
        {
            ownerRepository.DeleteOwner(id);
        }

        public IEnumerable<Owner> GetAllOwners()
        {
            return ownerRepository.GetAllOwners();
        }

        public Owner GetOwnerById(int id)
        {
            return ownerRepository.GetOwnerById(id);
        }

        public void UpdateOwner(Owner owner)
        {
            ownerRepository.UpdateOwner(owner);
        }
    }
}
