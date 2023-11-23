using YuGiOh.Domain.Models;

namespace YuGiOh.ApplicationCore.DTO {
    public class RegisterUserRequest {
        public string Name { get; set; }
        public string Nick { get; set; }
        public string Password { get; set; }
        public string Province { get; set; }
        public string Township { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public List<int> Roles { get; set; }
        public string Code { get; set; }
    }
}

