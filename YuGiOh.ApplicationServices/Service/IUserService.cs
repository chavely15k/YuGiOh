using YuGiOh.ApplicationCore.DTO;
using YuGiOh.Domain.Models;
namespace YuGiOh.ApplicationServices.Service;

public interface IUserService
{
    // public Task<IEnumerable<User>> GetUsersAsync();
    public Task<ResponseUserDto> RegisterUserAsync(UserDto register);
    public Task<ResponseUserDto> LoginAsync(LoginDto loginDto);
    public Task<bool> IsNickTakenAsync(string nick);
    public Task<User> GetUserByNickAsync(string nick);
    public Task<ResponseUserDto> AddRoleAsync(RoleAssignDto roleAssign);
    public Task DeleteAsync(int userId);
    public Task<RegisterDto> UpdateUser(UserDto register);
    public Task<User> GetUserByIdAsync(int userId);
}
