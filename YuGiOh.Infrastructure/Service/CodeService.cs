using YuGiOh.Domain.Models;
using YuGiOh.ApplicationServices.Service;
using YuGiOh.ApplicationCore.Repository;
using System.Data.Common;

namespace YuGiOh.Infrastructure.Service {
    public class CodeService : ICodeService
    {
        protected readonly IDataRepository Repository;
        public CodeService(IDataRepository dataRepository) {
            this.Repository = dataRepository;
        }
        public async Task<string> GenerateAsync()
        {
            string random = RandomGenerator();
            await SetAsync(random);
            return random;
        }

        public async Task<string> GetAsync()
        {            
            Code code = (await Repository.GetAllAsync<Code>()).ToList()[0];
            return code.Text;
        }

        public async Task SetAsync(string text)
        {
            List<Code> code = (await Repository.GetAllAsync<Code>()).ToList();
            if (code.Count() == 0) {
                await Repository.CreateAsync<Code>(new Code() { Id = Guid.NewGuid(), Text = text});
            }
            else {
                code[0].Text = text;
                await Repository.UpdateAsync<Code>(code[0]);
            }
        }

        protected string RandomGenerator() {
            string result = new Random().NextDouble().ToString();
            return result;
        }
    }
}