using UserService.Entities;

namespace UserService.Repositories.User
{
    public interface IUserRepository
    {
        Task<List<UserEntity>> GetUsersAsync(int skip, int take);

        Task<bool> PayMoneyAsync(decimal payment, Guid userId);
    }
}
