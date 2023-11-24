using Newtonsoft.Json;
using YuGiOh.Domain.Models;
using YuGiOh.ApplicationCore.Repository;

namespace YuGiOh.ApplicationServices.Seed {
    public class CodeSeed {
        public readonly IDataRepository dataRepository;
        public CodeSeed(IDataRepository repository) {
            this.dataRepository = repository;
        }
        public async Task SetInitialCodeAsync() {
            int cant = (await dataRepository.GetAllAsync<Code>()).Count();
            if (cant == 0) {
                Code code = await GetInitialCodeAsync();
                await dataRepository.CreateAsync<Code>(code);
            }
        }
        public static async Task<Code> GetInitialCodeAsync() {
            string? json = await File.ReadAllTextAsync("Data/CodeSeedData.json");
            Dictionary<string, Code> data = 
                JsonConvert.DeserializeObject<Dictionary<string, Code>>(json);
            return data["Code"];
        }
    }
}