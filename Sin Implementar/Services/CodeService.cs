using YuGiOh.ApplicationCore.Services;
using YuGiOh.Domain.Models;
using YuGiOh.ApplicationCore.Repositories;

namespace YuGiOh.Infrastructure.Services {
    public class CodeService : ICodeService
    {
        protected readonly IDataRepository Repository;
        public CodeService(IDataRepository dataRepository) {
            this.Repository = dataRepository;
        }
        public async Task<string> Generate()
        {
            string random = RandomGenerator();
            await Set(random);
            return random;
        }

        public async Task<string> Get()
        {
            Code? code = await Repository.GetByIdAsync<Code>(1);
            if (code == null) return "";
            else {
                return code.Text;
            }
        }

        public async Task Set(string text)
        {
            Code code = await Repository.SingleOrDefaultAsync<Code>(e => e.Id == 1);
            throw new NotImplementedException();
        }

        protected string RandomGenerator() {
            return "abcd1234";
        }
    }
}