using YuGiOh.ApplicationCore.DTO;
using YuGiOh.Domain.Models;
namespace YuGiOh.ApplicationServices.Service;

public interface IUserService
{
    // public Task<IEnumerable<User>> GetUsersAsync();
    public Task<RegisterUserDto> RegisterUserAsync(RegisterUserDto registerDto);
    public Task<bool> LoginAsync(LoginRequestDto loginDto);
    public Task<bool> IsNickTakenAsync(string nick);
    public Task AddRoleAsync(AddRoleDto addRoleDto);
    public Task DeleteAsync(LoginRequestDto loginDto);
    public Task<User> GetUserByIdAsync(Guid userId);
}
