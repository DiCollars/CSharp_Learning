using Microsoft.EntityFrameworkCore;
using UserService.Entities;

namespace UserService.Data
{
    public class UserDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; } = null!;

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            Database.EnsureCreated();

            if(Users.Any() != true)
            {
                Users.Add(new UserEntity 
                { 
                    Id = Guid.NewGuid(),
                    Email = "test@mail.com",
                    Name = "Danny",
                    Password = "0000",
                    AccountMoney = 5000.51M
                });
                SaveChanges();
            }
        }
    }
}
