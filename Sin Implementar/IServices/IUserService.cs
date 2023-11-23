using YuGiOh.Domain.Models;
using YuGiOh.ApplicationCore.DTO;

namespace YuGiOh.ApplicationCore.Services {
    public interface IUserService {
        public Task<User?> Create(RegisterUserRequest registerUserRequest);
        public Task<User?> Get(LoginRequest loginRequest);
    }
}
