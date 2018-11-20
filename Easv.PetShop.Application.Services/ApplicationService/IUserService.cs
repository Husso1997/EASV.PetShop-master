using System;
using System.Collections.Generic;
using System.Text;

namespace Easv.PetShop.Core.Application.Services.ApplicationService
{
    public interface IUserService<T>
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Add(T entity);
        void Edit(T entity);
        void Remove(long id);
        void CreatePassword(string password, out byte[] passwordHash,
            out byte[] passwordSalt);
        
    }
}
