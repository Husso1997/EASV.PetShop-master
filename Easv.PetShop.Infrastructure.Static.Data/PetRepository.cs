using Easv.PetShop.Application.Services.DomainService;
using Easv.PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easv.PetShop.Infrastructure.Static.Data
{
    public class PetRepository : IPetRepository
    {

        public PetRepository()
        {
            
        }

        public void CreatePet(Pet pet)
        {
            pet.PetID = FakeDB.petId++;
            var petList = FakeDB.petList.ToList();
            petList.Add(pet);
            FakeDB.petList = petList;
        }

        public bool DeletePet(int id)
        {
            Pet pet = GetPetByID(id);
            if (pet != null)
            {
                var petList = FakeDB.petList.ToList();
                petList.Remove(pet);
                FakeDB.petList = petList;
                return true;
            }
            return false;
        }

        public IEnumerable<Pet> GetAllPets()
        {
            return FakeDB.petList;
        }

        public void UpdatePet(Pet pet)
        {
            Pet PetToUpdate = GetPetByID(pet.PetID);
            PetToUpdate.PetName = pet.PetName;
            PetToUpdate.PetPreviousOwner = pet.PetPreviousOwner;
            PetToUpdate.PetPrice = pet.PetPrice;
            PetToUpdate.SoldDate = pet.SoldDate;
            PetToUpdate.PetColor = pet.PetColor;
        }

        public Pet GetPetByID(int petId)
        {
            foreach (var pet in FakeDB.petList.ToList())
            {
                if (pet.PetID == petId)
                {
                    return pet;
                }
            }
            return null;
        }

        public Owner GetOwner(int petId)
        {
            Owner owner = GetPetByID(petId).PetOwner;
            return owner;
        }
    }
}
