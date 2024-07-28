using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Entities;

namespace UserService.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<List<UserEntity>> GetUsersAsync(int skip, int take)
        {
            return _context.Users.Skip(skip).Take(take).ToListAsync();
        }

        public async Task<bool> PayMoneyAsync(decimal payment, Guid userId)
        {
            var user = await _context.Users.FirstAsync(u => u.Id == userId);

            if (payment < 0)
            {
                return false;
            }

            if (payment > user.AccountMoney) 
            {
                return false;
            }

            user.AccountMoney = user.AccountMoney - payment;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
