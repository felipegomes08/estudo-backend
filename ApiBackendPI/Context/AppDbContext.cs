using ApiBackendPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBackendPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Nome = "Felipe Gomes",
                    Email = "felipe@gmail.com",
                    Senha = "123"
                },
                new User
                {
                    Id = 2,
                    Nome = "Wilson Assis",
                    Email = "wilson@gmail.com",
                    Senha = "456"
                },
                new User
                {
                    Id = 3,
                    Nome = "Itallo Andrade",
                    Email = "itallo@gmail.com",
                    Senha = "789"
                }
                );
        }
    }
}
