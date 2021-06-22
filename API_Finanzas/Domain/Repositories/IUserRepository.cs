using API_Finanzas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Finanzas.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task<User> FindById(int id);
        Task<User> FindByEmail(string email);
        User FindByEmailandPassword(string email, string password);
        Task AddAsync(User user);
        void Update(User user);
        void Remove(User user);
    }
}
