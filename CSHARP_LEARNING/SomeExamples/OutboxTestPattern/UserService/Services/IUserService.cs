using UserService.Models;

namespace UserService.Services
{
    public interface IUserService
    {
        public Task<List<UserShortModel>> GetUsersAsync(int skip, int take);

        Task<bool> PayMoneyAsync(decimal payment, Guid userId);
    }
}
