using Easv.PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easv.PetShop.Infrastructure.Data
{
    public class DbInitializer
    {
        

        public static void SeedDb(PetAppContext pac)
        {
            byte[] passwordHashDavid, passwordSaltDavid;
            CreatePassword("1234", out passwordHashDavid, out passwordSaltDavid);   
            pac.Database.EnsureDeleted();
            pac.Database.EnsureCreated();

            Random random = new Random();
            string[] randomNames = { "Peter", "James", "Arnold", "Muscle", "NoNameDog" };

            for (int i = 0; i < 10; i++)
            {
                Owner owner = new Owner
                {
                    Name = randomNames[random.Next(0, 4)],
                };
                pac.Owners.Add(owner);
                Pet pet = new Pet
                {
                    PetName = randomNames[random.Next(0, 4)],
                    PetType = GetEnumType(random.Next(0, 3)),
                    PetPrice = random.NextDouble(),
                    PetPreviousOwner = "None",
                    PetBirthDate = new DateTime(1995, 2, 20),
                    SoldDate = DateTime.Today,
                    PetOwner = owner,
                };
                pac.Users.Add(new User
                {
                    IsAdmin = true,
                    Username = "David",
                    PasswordHash = passwordHashDavid,
                    PasswordSalt = passwordSaltDavid
                });
                pac.Pets.Add(pet);
                
            }

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

        public static MyEnum GetEnumType(int index)
        {
            switch (index)
            {
                case 0:
                    return MyEnum.Dog;
                case 1:
                    return MyEnum.Cat;
                case 2:
                    return MyEnum.Goat;
                default:
                    break;
            }
            return MyEnum.Unknown;
        }

    }
}
