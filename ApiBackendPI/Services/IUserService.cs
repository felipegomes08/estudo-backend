using ApiBackendPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBackendPI.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<IEnumerable<User>> GetUserByNome(string nome);
        Task CreateUser(User user);

        Task UpdateUser(User user);
        Task DeleteUser(User user);
    }
}
