using System.Text.Json.Serialization;

namespace UserService.Models
{
    public class UserFullModel
    {
        [JsonIgnore]
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
