using Common;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using UserService.Models;
using UserService.Services;

namespace UserService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(
            ILogger<UserController> logger,
            IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost]
        [Route("make-order")]
        public async Task MakeOrderAsync(
            [FromQuery] Guid userId,
            [FromQuery] Guid orderId)
        {
            HttpMessageHandler handler = new HttpClientHandler();
            using (var client = new HttpClient(handler, false))
            {
                using var result = await client.PostAsync(
                    $"https://localhost:7064/update-order-info?orderId={orderId}&orderStatus={OrderStatus.Ordered}&userId={userId}",
                    null);
            }
        }

        [HttpGet]
        [Route("get-order-info")]
        public async Task<object?> GetOrderInfoAsync(
            [FromQuery] Guid orderId)
        {
            HttpMessageHandler handler = new HttpClientHandler();
            using (var client = new HttpClient(handler, false))
            {
                using var result = await client.GetAsync($"https://localhost:7064/get-order-info?orderId={orderId}");
                return JsonConvert.DeserializeObject<OrderInfo>(await result.Content.ReadAsStringAsync());
            }
        }

        [HttpGet]
        [Route("get-users")]
        public async Task<List<UserShortModel>> GetUsersAsync(
            [FromQuery] int skip = 0,
            [FromQuery] int take = 10)
        {
            return await _userService.GetUsersAsync(skip, take);
        }

        [HttpGet]
        [Route("get-users")]
        public async Task<List<UserShortModel>> GetUsersAsync(
            [FromQuery] decimal payment = 0,
            [FromQuery] Guid userId)
        {
            return await _userService.GetUsersAsync(skip, take);
        }
    }
}