using YuGiOh.ApplicationCore.DTO;
using YuGiOh.Domain.Models;
namespace YuGiOh.ApplicationServices.Service;

public interface IUserService
{
    // public Task<IEnumerable<User>> GetUsersAsync();
    public Task<RegisterDto> RegisterUserAsync(UserDto registerDto);
    public Task<LoginResponseDto> LoginAsync(LoginDto loginDto);
    public Task<bool> IsNickTakenAsync(string nick);
    public Task<User> GetUserByNickAsync(string nick);
    public Task AddRoleAsync(AddRoleDto addRoleDto);
    public Task DeleteAsync(LoginDto loginDto);
    public Task<User> GetUserByIdAsync(int userId);

}
