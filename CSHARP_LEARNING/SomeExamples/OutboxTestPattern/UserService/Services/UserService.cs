using Microsoft.AspNetCore.Mvc;
using UserService.Entities;
using UserService.Models;
using UserService.Repositories.User;

namespace UserService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<List<UserShortModel>> GetUsersAsync(int skip, int take)
        {
            return (await _userRepository.GetUsersAsync(skip, take))
                .Select(u => new UserShortModel { Id = u.Id, Name = u.Name})
                .ToList();
        }

        public async Task<bool> PayMoneyAsync(decimal payment, Guid userId)
        {
            return await _userRepository.PayMoneyAsync(payment, userId);
        }
    }
}
