using YuGiOh.Domain.Models;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.ApplicationCore.Repositories;
using System.Drawing;
using YuGiOh.ApplicationCore.Services;

namespace YuGiOh.Infrastructure.Services {
    public class UserService : IUserService {

        protected readonly IDataRepository Repository;
        public UserService(IDataRepository dataRepository) {
            this.Repository = dataRepository;
        }

        public async Task<User?> Create(RegisterUserRequest registerUserRequest) {
            var u = await Repository.SingleOrDefaultAsync<User>
                (x => x.Nick == registerUserRequest.Nick);
            if (u != null) return null;            
            return await MapCreateFromRegisterUserRequestToUser(registerUserRequest);
        }
        public async Task<User?> Get(LoginRequest loginRequest) {
            var user = await Repository.SingleOrDefaultAsync<User>
                (x => x.Nick == loginRequest.Nick && x.Password == loginRequest.Password);
            if (user == null) return null;
            else return user;
        }
        protected async Task<User?> MapCreateFromRegisterUserRequestToUser(RegisterUserRequest registerUserRequest) {
            if (registerUserRequest.Roles.Count() == 0) return null;
            User user = new() {
                Name = registerUserRequest.Name,
                Nick = registerUserRequest.Nick,
                Password = registerUserRequest.Password,
                Province = registerUserRequest.Province,
                Township = registerUserRequest.Township,
                Address = registerUserRequest.Address,
                PhoneNumber = registerUserRequest.PhoneNumber
            };

            if (registerUserRequest.Roles.Contains(1)) {
                await Repository.CreateAsync<User>(user);

                await Repository.CreateAsync<UserRole>(new UserRole() {
                    Id = (await Repository.GetAllAsync<UserRole>()).Count(),
                    UserId = user.Id, 
                    RoleId = 1,
                });
            }
            if (registerUserRequest.Roles.Contains(2)) {
                if (await CheckCode(registerUserRequest.Code)) {
                    if (!registerUserRequest.Roles.Contains(1)){
                        await Repository.CreateAsync<User>(user);
                    }
                    await Repository.CreateAsync<UserRole>(new UserRole() {
                        Id = (await Repository.GetAllAsync<UserRole>()).Count(),
                        UserId = user.Id, 
                        User = user,
                        RoleId = 2
                    });
                }
            }
            return user;
        }
        protected async Task<bool> CheckCode(string code) {
            var textResult = await Repository.SingleOrDefaultAsync<Code>(c => c.Text == code);
            return textResult != null;
        }
    }
}
