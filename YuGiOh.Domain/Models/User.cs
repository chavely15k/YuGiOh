﻿using YuGiOh.Domain.Enums;

namespace YuGiOh.Domain.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Nick { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Province { get; set; }
        public string Township { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public List<Deck> Decks { get; set; }
        public List<UserRole> Roles { get; set; }

        public object GetById()
        {
            return Id;
        }
    }
}
