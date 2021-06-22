using API_Finanzas.Domain.Models;
using API_Finanzas.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Finanzas.Domain.Services
{
    public interface IUserService
    {
        AuthenticationResponse Authenticate(AuthenticationRequest request);
        Task<IEnumerable<User>> ListAsync();
        Task<UserResponse> GetByIdAsync(int id);
        Task<UserResponse> GetByEmailAsync(string email);
        Task<UserResponse> SaveAsync(User user);
        Task<UserResponse> UpdateAsync(int id, User user);
        Task<UserResponse> DeleteAsync(int id);
    }
}
