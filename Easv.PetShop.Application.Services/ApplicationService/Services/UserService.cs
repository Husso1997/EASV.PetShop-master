﻿using Easv.PetShop.Core.Application.Services.DomainService;
using Easv.PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easv.PetShop.Core.Application.Services.ApplicationService.Services
{
    public class UserService : IUserService<User>
    {
        private IUserRepository<User> _repo; 

        public UserService(IUserRepository<User> repo)
        {
            _repo = repo;
        }

        public void Add(User entity)
        {
            _repo.Add(entity);
        }

        public void Edit(User entity)
        {
            _repo.Edit(entity);
        }

        public User Get(long id)
        {
            return _repo.Get(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _repo.GetAll();
        }

        public void Remove(long id)
        {
            _repo.Remove(id);
        }
    }
}
