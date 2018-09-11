using Easv.PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easv.PetShop.Core.Application.Services.DomainService
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> GetAllOwners();

        void DeleteOwner(int id);

         Owner GetOwnerById(int id);

        void CreateOwner(Owner owner);

        void UpdateOwner(Owner owner);
    }
}
