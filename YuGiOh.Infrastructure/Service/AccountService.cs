using System.Threading;
using System.Net.Mime;
using YuGiOh.Domain.Models;
using YuGiOh.ApplicationCore.Map;
using YuGiOh.ApplicationServices.Service;

namespace YuGiOh.Infrastructure.Service
{
    public class AccountService : DataService, IAccountService {
        public CodeService(IDataRepository dataRepository, YuGiOhAutoMapper autoMapper) :
            base(dataRepository, autoMapper){  }  
        public async Task<User?> RegisterUserAsync(RegisterUserRequest registerUserRequest) {
            User user = autoMapper.Map<User>(registerUserRequest);
            return user;
        }
        public async Task<User?> LoginAsync(LoginRequest loginRequest) { return new User(); }
        public async Task<User?> AddRoleToUserAsync(AddRoleRequest addRoleRequest) { return new User(); }
        public async Task DeleteAsync(string nick) { }
    }
}