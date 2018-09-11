using Easv.PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easv.PetShop.Core.Application.Services.ApplicationService.Services
{
    public interface IOwnerService
    {
        IEnumerable<Owner> GetAllOwners();

        void DeleteOwner(int id);

        Owner GetOwnerById(int id);

        void CreateOwner(Owner owner);

        void UpdateOwner(Owner owner);

        List<Pet> GetOwnerPets(int id);
    }
}
