using YuGiOh.Domain.Enums;

namespace YuGiOh.Domain.Models
{
    public class User : Entity
    {
       
        public string Nick { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Province { get; set; }
        public string Township { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}
