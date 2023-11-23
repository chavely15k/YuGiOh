using System.Dynamic;
using System.Text.Json;
using YuGiOh.Domain.Models;
using YuGiOh.ApplicationCore.Repositories;
using Newtonsoft.Json;

namespace YuGiOh.Infrastructure.Seed {
    public class CodeSeed {
        public readonly IDataRepository dataRepository;
        public CodeSeed(IDataRepository repository) {
            this.dataRepository = repository;
        }
        public async Task SetInitialCodeAsync() {
            Code code = await GetInitialCodeAsync();
            await dataRepository.CreateAsync<Code>(code);
        }
        public static async Task<Code> GetInitialCodeAsync() {
            string? data = await File.ReadAllTextAsync("Data/CodeSeedData.json");
            Dictionary<string, Code> aux = 
                JsonConvert.DeserializeObject<Dictionary<string, Code>>(data);
            Code code = new()
            {
                Id = aux["Code"].Id,
                Text = aux["Code"].Text
            };
            return code;
        }
    }
}
