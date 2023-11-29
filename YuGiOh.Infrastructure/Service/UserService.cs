using AutoMapper;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.ApplicationCore.Repository;
using YuGiOh.ApplicationServices.Service;
using YuGiOh.Domain.Models;
using YuGiOh.Domain.Enums;
using YuGiOh.ApplicationServices.Service.AbstractClass;
using Microsoft.EntityFrameworkCore;

namespace YuGiOh.Infrastructure.Service;

public class UserService : AbstractDataServices, IUserService
{
    public UserService(IEntityRepository dataRepository, IMapper mapper) : base(dataRepository, mapper)
    {
    }

    public Task AddRoleAsync(AddRoleDto addRoleDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(LoginRequestDto loginDto)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> LoginAsync(LoginRequestDto loginDto)
    {
        var foundUser = (await _dataRepository.FindAsync<User>(u => u.Nick == loginDto.Nick)).ToList();
        return foundUser.Count != 0 ? foundUser[0].Password == loginDto.Password : false;
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

    // public async Task<User> GetUserByNickAsync(string nick)
    // {
    //     var foundUser = await _dataRepository
    //         .Include(u => u.PropiedadDeNavegacion) // Reemplaza PropiedadDeNavegacion con el nombre real de tu propiedad de navegación
    //         .FirstOrDefaultAsync(u => u.Nick == nick);

    //     return foundUser;
    // }



    public async Task<User?> GetUserByIdAsync(int id)
    {
        var foundUsers = await _dataRepository.GetByIdAsync<User>(id);
        return foundUsers;
    }

    public async Task<RegisterDto> RegisterUserAsync(UserDto registerDto)
    {
        List<UserRole> roles = new();
        var _user = _mapper.Map<User>(registerDto);

        foreach (var role in registerDto.Roles)
        {
            if (role == (int)RoleType.Admin)
            {
                if (!await CheckCode(registerDto.Code))
                {

                    return new RegisterDto
                    {
                        Message = "Invalid admin code",
                        Success = false
                    };
                }
            }

            roles.Add(await GetUserRoles(role, _user));
        }
        _user.Roles = roles;
        await _dataRepository.CreateAsync<User>(_user);

        return new RegisterDto
        {
            Message = "Succesful Register",
            Success = true,
        };
    }

    private async Task<Role?> GetRole(int roleType)
    {
        List<Role> userRoles = (await _dataRepository.GetAllAsync<Role>()).ToList();
        Role? matchingUserRole = userRoles.FirstOrDefault(ur => ur.Type == roleType);
        return matchingUserRole;
    }
    private async Task<UserRole> GetUserRoles(int roleType, User user)
    {
        //Todo : Debe haber una comprobacion de si role no existe
        var role = await GetRole(roleType);
        UserRole userRole = new(user.Id, role.Id);
        return userRole;
    }
    //Todo: Hay que hacer el admin y el check
    protected async Task<bool> CheckCode(string code)
    {
        var textResult = await _dataRepository.FindAsync<Code>(c => c.Text == code);
        return textResult.Count() != 0;
    }

}