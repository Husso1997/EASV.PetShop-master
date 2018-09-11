using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easv.PetShop.Core.Application.Services.DomainService;
using Easv.PetShop.Core.Entities;

namespace Easv.PetShop.Infrastructure.Static.Data
{
    public class OwnerRepository : IOwnerRepository
    {
        public void CreateOwner(Owner owner)
        {
            owner.Id = FakeDB.ownerId++;
            var ownerList = FakeDB.ownerList.ToList();
            ownerList.Add(owner);
            FakeDB.ownerList = ownerList;
        }

        public void DeleteOwner(int id)
        {
            var ownerList = FakeDB.ownerList.ToList();
           Owner owner = GetOwnerById(id);
            if (owner != null)
            {
                ownerList.Remove(owner);
            }
            FakeDB.ownerList = ownerList;
        }

        public Owner GetOwnerById(int id)
        {
            foreach(var owner in FakeDB.ownerList.ToList())
            {
                if(owner.Id == id)
                {
                    return owner;
                }
            }
            return null;
        }

        public IEnumerable<Owner> GetAllOwners()
        {
            return FakeDB.ownerList;
        }

        public void UpdateOwner(Owner owner)
        {
            Owner OwnerToUpdate = GetOwnerById(owner.Id);

            OwnerToUpdate.Name = owner.Name;
            
        }
    }
}
