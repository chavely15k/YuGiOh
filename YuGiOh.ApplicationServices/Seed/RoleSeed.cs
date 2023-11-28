using YuGiOh.Domain.Models;
using YuGiOh.ApplicationCore.Repository;
using Newtonsoft.Json;

namespace YuGiOh.ApplicationServices.Seed {
    public class RoleSeed {
        public readonly IDataRepository Repository;
        public RoleSeed(IDataRepository repository) {
            this.Repository = repository;
        }
        public async Task SetInitialRoleAsync() {
            int cant = (await Repository.GetAllAsync<Role>()).Count();
            if (cant == 0) {
                string? data = await File.ReadAllTextAsync("Data/RoleSeedData.json");
                Dictionary<string, Role> roles = 
                    JsonConvert.DeserializeObject<Dictionary<string, Role>>(data);
                foreach (var type in roles.Keys) {
                    await Repository.CreateAsync<Role>(new Role() {
                        Id = roles[type].Id,
                        enumValue = roles[type].enumValue
                    });
                }

            }
        }
    }
}
