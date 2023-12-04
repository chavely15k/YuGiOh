using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.ApplicationCore.Repository;
using YuGiOh.ApplicationServices.Service;
using YuGiOh.Domain.Models;
using YuGiOh.Infrastructure;
using YuGiOh.Infrastructure.Repository;

namespace YuGiOh.Tests {
    public class RepositoryTest : BaseTest {
        private YuGiOhDbContext Context;
        private IUserService userService;
        public RepositoryTest() {
            Context = Container.GetRequiredService<YuGiOhDbContext>();
            userService = Container.GetRequiredService<IUserService>();
            
        }
        [Fact]
        public async Task DeleteUserCascadeTestAsync() {

            //Arrange
            string? data = await GetData("usersDelete");
            IList<string> deletes = GetDeserializedData<IList<string>>(data)["Delete"];
            data = await GetData("users");
            IList<UserDto> users = GetDeserializedData<IList<UserDto>>(data)["Users"];

            foreach (var u in users) {
                await userService.RegisterUserAsync(u);
            }
            int x = Context.Set<UserRole>().Count();
            User? user;
            foreach (var d in deletes)
            {
                user = await userService.GetUserByNickAsync(d);
                await userService.DeleteAsync(user.Id);
            }
            int y = Context.Set<UserRole>().Count();
            Assert.True(x == 2 && y==0);
        }
        
    }
}