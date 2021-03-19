using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abgular_API.Helper;
using Abgular_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Abgular_API.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserEntity> UserEntities { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity()
                {
                    Id = 1,
                    FullName = "Nayan Raval",
                    Email = "ny@gmail.com",
                    Password = Cryptography.HashPassword("Test@123"),
                },
                new UserEntity()
                {
                    Id = 2,
                    FullName = "Fenal",
                    Email = "sample@gmail.com",
                    Password = Cryptography.HashPassword("Test@ABC"),
                }
                );
        }
    }
}
