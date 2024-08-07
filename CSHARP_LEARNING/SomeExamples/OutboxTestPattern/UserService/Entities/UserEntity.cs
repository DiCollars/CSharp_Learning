﻿namespace UserService.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public decimal AccountMoney { get; set; }
    }
}
