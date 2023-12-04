using AutoMapper;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.ApplicationCore.Repository;
using YuGiOh.ApplicationServices.Service;
using YuGiOh.Domain.Models;
using YuGiOh.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace YuGiOh.Infrastructure.Service;

public class UserService : AbstractDataServices, IUserService
{
    private readonly IRoleService _roleService;
    public UserService(IEntityRepository dataRepository, IMapper mapper, IRoleService roleService) : base(dataRepository, mapper)
    {
        _roleService = roleService;
    }
    public Task DeleteAsync(LoginDto loginDto)
    {
        throw new NotImplementedException();
    }
    public async Task<ResponseUserDto> LoginAsync(LoginDto loginDto)
    {

        var _user = await GetUserByNickAsync(loginDto.Nick);

        if (_user != null && _user.Password == loginDto.Password)
        {
            var rolesId = _user.Roles.Select(r => r.RoleId).ToList();
            var roleTypes = new List<int>();

            foreach (var roleId in rolesId)
            {
                var role = await _roleService.GetRoleByIdAsync(roleId);
                roleTypes.Add(role.Type);
            }

            return new ResponseUserDto
            {
                Name = _user.Name,
                Id = _user.Id,
                Nick = _user.Nick,
                Roles = roleTypes,
                Message = "Succesful Login ",
                Success = true
            };
        }

        else
        {
            return new ResponseUserDto
            {
                Id = null,
                Message = "Worng Credentials",
                Success = false
            };
        }
    }
    public async Task<bool> IsNickTakenAsync(string nick)
    {
        var foundUsers = await _dataRepository.FindAsync<User>(u => u.Nick == nick);
        return foundUsers.Count() != 0;
    }
    public async Task<User> GetUserByNickAsync(string nick)
    {
        var foundUsers = await _dataRepository
            .Include<User>(u => u.Roles) // Assuming Include is part of IEntityRepository
            .Where(u => u.Nick == nick)
            .ToListAsync();
        return foundUsers.FirstOrDefault();
    }
    public async Task<User?> GetUserByIdAsync(int id)
    {
        var foundUsers = await _dataRepository.GetByIdAsync<User>(id);
        return foundUsers;
    }
    public async Task<ResponseUserDto> RegisterUserAsync(UserDto registerDto)
    {
        List<UserRole> roles = new();
        var _user = _mapper.Map<User>(registerDto);

        foreach (var role in registerDto.Roles)
        {
            if (role == (int)RoleType.Admin)
            {
                if (!await CheckCode(registerDto.Code))
                {

                    return new ResponseUserDto
                    {
                        Id = null,
                        Message = "Invalid admin code",
                        Success = false
                    };
                }
            }

            roles.Add(await GetUserRoles(role, _user));
        }
        _user.Roles = roles;
        await _dataRepository.CreateAsync<User>(_user);

        return new ResponseUserDto
        {
            Id = null,
            Message = "Succesful Register",
            Success = true
        };
    }
    private async Task<Role?> GetRole(int roleType)
    {
        List<Role> userRoles = (await _dataRepository.GetAllAsync<Role>()).ToList();
        Role? matchingUserRole = userRoles.FirstOrDefault(ur => ur.Type == roleType);
        return matchingUserRole;
    }
    private async Task<UserRole?> GetUserRoles(int roleType, User user)
    {
        var role = await GetRole(roleType);
        return role != null ? new(user.Id, role.Id) : null;
    }
    private async Task<bool> CheckCode(string code)
    {
        var textResult = await _dataRepository.FindAsync<Code>(c => c.Text == code);
        return textResult.Count() != 0;
    }
    public async Task<ResponseUserDto> AddRoleAsync(RoleAssignDto roleAssign)
    {
        var user = await _dataRepository.GetByIdAsync<User>(roleAssign.Id);
        if (user != null)
        {
            List<UserRole> roles = new();
            foreach (var role in roleAssign.Roles)
            {
                if (role == (int)RoleType.Admin)
                {
                    if (!await CheckCode(roleAssign.Code))
                    {

                        return new ResponseUserDto
                        {
                            Id = null,
                            Message = "Invalid admin code",
                            Success = false
                        };
                    }
                }
                roles.Add(await GetUserRoles(role, user));
            }
            user.Roles = roles;
            await _dataRepository.UpdateAsync<User>(user);
            List<int> roleType = user.Roles.Select(r => r.Role.Type).ToList();
            return new ResponseUserDto
            {
                Name = user.Name,
                Id = user.Id,
                Nick = user.Nick,
                Roles = roleType,
                Message = "Role assigned successfully",
                Success = true
            };

        }
        return new ResponseUserDto
        {
            Id = null,
            Message = "Invalid User Id",
            Success = false
        };
    }
    public async Task DeleteAsync(int userId)
    {
        await _dataRepository.DeleteAsync<User>(userId);
    }
    public Task<RegisterDto> UpdateUser(UserDto register)
    {
        throw new NotImplementedException();
    }
}