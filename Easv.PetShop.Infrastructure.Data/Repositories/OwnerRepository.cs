using Easv.PetShop.Core.Application.Services.DomainService;
using Easv.PetShop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easv.PetShop.Infrastructure.Data
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly PetAppContext _pac;

        public OwnerRepository(PetAppContext pac)
        {
            _pac = pac;
        }

        public void CreateOwner(Owner owner)
        {
            _pac.Owners.Add(owner);
            _pac.SaveChanges();
        }

        public void DeleteOwner(int id)
        {
            Owner owner = GetOwnerById(id);
            _pac.Owners.Remove(owner);
            _pac.SaveChanges();
        }

        public IEnumerable<Owner> GetAllOwners()
        {
            return _pac.Owners.Include(o => o.Pets);
        }

        public Owner GetOwnerById(int id)
        {
            return _pac.Owners.Include(o => o.Pets).FirstOrDefault(o => o.Id == id);
                
        }

        public void UpdateOwner(Owner owner)
        {
            _pac.Attach(owner).State = EntityState.Modified;
            _pac.SaveChanges();
        }
    }
}
