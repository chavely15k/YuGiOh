using YuGiOh.ApplicationCore.DTO;

namespace YuGiOh.ApplicationServices.Service {
    public interface IAccountService {
        public Task<User?> RegisterUserAsync(RegisterUserRequest registerUserRequest);
        public Task<User?> LoginAsync(LoginRequest loginRequest);
        public Task<User?> AddRoleToUserAsync(AddRoleRequest addRoleRequest);
        public Task DeleteAsync(string nick);        
    }
}