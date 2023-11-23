using System.Dynamic;
using System.Text.Json;
using YuGiOh.Domain.Models;
using YuGiOh.ApplicationCore.Repositories;
using Newtonsoft.Json;

namespace YuGiOh.Infrastructure.Seed {
    public class RoleSeed {
        public readonly IDataRepository dataRepository;
        public RoleSeed(IDataRepository repository) {
            this.dataRepository = repository;
        }
        public async Task SetInitialRoleAsync() {
            List<Role> roles = await GetInitialRoleAsync();
            foreach (Role role in roles) {
                await dataRepository.CreateAsync<Role>(role);
            }
        }
        public static async Task<List<Role>> GetInitialRoleAsync() {
            string? data = await File.ReadAllTextAsync("Data/RoleSeedData.json");
            Dictionary<string, Role> aux = 
                JsonConvert.DeserializeObject<Dictionary<string, Role>>(data);
            List<Role> roles = new List<Role>();
            foreach (var type in aux.Keys) {
                roles.Add(new Role() {
                    Id = aux[type].Id,
                    Type = aux[type].Type
                });
            }
            return roles;
        }
    }
}
