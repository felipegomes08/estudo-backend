using ApiBackendPI.Context;
using ApiBackendPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBackendPI.Services
{
    public class UsersService : IUserService
    {
        private readonly AppDbContext _context;

        public UsersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            try
            {
            return await _context.Users.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<User>> GetUserByNome(string nome)
        {
            IEnumerable<User> users;
            if (!string.IsNullOrWhiteSpace(nome))
            {
                users = await _context.Users.Where(n => n.Nome.Contains(nome)).ToListAsync();
            }
            else
            {
                users = await GetUsers();
            }
            return users;
        }
        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }
        public async Task CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteUser(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
