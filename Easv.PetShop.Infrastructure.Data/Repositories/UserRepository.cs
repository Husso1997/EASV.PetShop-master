using Easv.PetShop.Core.Application.Services.DomainService;
using Easv.PetShop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easv.PetShop.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        private PetAppContext _pac;


        public UserRepository(PetAppContext pac)
        {
            _pac = pac;
        }

        public IEnumerable<User> GetAll()
        {
            return _pac.Users;
        }

        public User Get(long id)
        {
            return _pac.Users.FirstOrDefault(b => b.Id == id);
        }

        public void Add(User entity)
        {
            _pac.Users.Add(entity);
            _pac.SaveChanges();
        }

        public void Edit(User entity)
        {
            _pac.Entry(entity).State = EntityState.Modified;
            _pac.SaveChanges();
        }

        public void Remove(long id)
        {
            var item = _pac.Users.FirstOrDefault(b => b.Id == id);
            _pac.Users.Remove(item);
            _pac.SaveChanges();
        }
    }
}
