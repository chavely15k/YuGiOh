namespace YuGiOh.ApplicationServices.Service {
    public interface IAccountService {
        public Task<User?> RegisterUserAsync(RegisterUserRequest registerUserRequest);
        
    }
}