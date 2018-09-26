using Easv.PetShop.Application.Services.DomainService;
using Easv.PetShop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easv.PetShop.Infrastructure.Data
{
    public class PetRepository : IPetRepository
    {
        private readonly PetAppContext _pac;

        public PetRepository(PetAppContext pac)
        {
            _pac = pac;
        }

        public void CreatePet(Pet pet)
        {
            _pac.Attach(pet).State = EntityState.Added;
            _pac.SaveChanges();
        }

        public bool DeletePet(int petId)
        {
            
            var pet = GetPetByID(petId);
            if(pet != null)
            {
            _pac.Pets.Remove(pet);
            _pac.SaveChanges();
                return true;
            }
            return false;

        }

        public IEnumerable<Pet> GetAllPets(Filter filter)
        {
            if(filter == null)
            {
                return _pac.Pets.Include(p => p.PetOwner).Include(p => p.PetColors).ThenInclude(pc => pc.Colour);
            }
            return _pac.Pets.Include(p => p.PetOwner).Include(p => p.PetColors).ThenInclude(pc => pc.Colour).
                Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage);
            
        }
        public Owner GetOwner(int petId)
        {
            Owner owner = GetPetByID(petId).PetOwner;
            return owner;
        }

        public Pet GetPetByID(int petId)
        {
            return _pac.Pets.Include(p => p.PetOwner).FirstOrDefault(p => p.PetID == petId);
        }

        public void UpdatePet(Pet pet)
        {
            _pac.Attach(pet).State = EntityState.Modified;
            _pac.Entry(pet).Reference(p => p.PetOwner).IsModified = true;
            _pac.Entry(pet).Collection(p => p.PetColors).IsModified = true;
            _pac.SaveChanges();
        }
    }
}
