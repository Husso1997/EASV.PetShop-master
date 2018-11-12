﻿using Easv.PetShop.Application.Services.DomainService;
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
            byte[] passwordHashDavid, passwordSaltDavid;
            CreatePassword("1234", out passwordHashDavid, out passwordSaltDavid);
            _pac = pac;

            pac.Users.Add(new User
            {
                IsAdmin = true,
                Username = "David",
                PasswordHash = passwordHashDavid,
                PasswordSalt = passwordSaltDavid
            });
            pac.SaveChanges();
        }

        public static void CreatePassword(string password, out byte[] passwordHash,
    out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
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
            if(filter.ItemsPrPage == 0 || filter.CurrentPage == 0)
            {
                return _pac.Pets;
            }
            return _pac.Pets.
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
            return _pac.Pets.Include(p => p.PetOwner).Include(p => p.PetColors).ThenInclude(pc => pc.Colour).FirstOrDefault(p => p.PetID == petId);
        }

        public void UpdatePet(Pet pet)
        {
            _pac.Attach(pet).State = EntityState.Modified;
            _pac.Entry(pet).Reference(p => p.PetOwner).IsModified = true;
            _pac.SaveChanges();
        }
    }
}
