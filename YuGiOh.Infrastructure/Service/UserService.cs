using AutoMapper;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.ApplicationCore.Repository;
using YuGiOh.ApplicationServices.Service;
using YuGiOh.Domain.Models;
using YuGiOh.Domain.Enums;

namespace YuGiOh.Infrastructure.Service;

public class UserService : AbstractDataService, IUserService
{
    public UserService(IDataRepository dataRepository, IMapper mapper) : base(dataRepository, mapper)
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

    public Task<bool> LoginAsync(LoginRequestDto loginDto)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> RegisterUserAsync(RegisterUserDto registerDto)
    {
        var _user = _mapper.Map<User>(registerDto);
        _user.Id = Guid.NewGuid();
        //Todo: es necesario implementar un task  que me deje obtener por Nick
        //Si no cuando de inserte un unsuario con un nick igual que el otro
        //Dara error al insertar en la Bd
        foreach (var role in registerDto.Roles)
        {
            if(role == (int)RoleType.Admin)
            {
                 if(await CheckCode(registerDto.Code))
                 {
                    //Todo: Si esto falla entonces hay que ver que se le manda al fronend 
                    //pero no se debe poder registrar el unsuario;
                    // return Error
                 }
            }
            _user.Roles = new List<UserRole>();
            _user.Roles.Add(await GetUserRoles(role,_user));
        }
        await _dataRepository.CreateAsync<User>(_user);
       
        return _user;
    }
    // Por Convenio Asumiremos que Admin en el valor 0 
    private async Task<Role?> GetRole(int roleType)
    {   
        List<Role> userRoles =  (await _dataRepository.GetAllAsync<Role>()).ToList();
        Role? matchingUserRole = userRoles.FirstOrDefault(ur => ur.enumValue == roleType);
        return matchingUserRole;
    }

    private async Task<UserRole> GetUserRoles(int roleType,User user)
    {
        //Todo : Debe haber una comprobacion de si role no existe
        var role = await GetRole(roleType);
        UserRole userRole = new(user.Id,role.Id);
        return userRole;
    }


    private async Task<bool> CheckCode(string code)
    {
        return true;
    }

}