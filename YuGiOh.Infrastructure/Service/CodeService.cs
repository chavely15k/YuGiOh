using YuGiOh.Domain.Models;
using YuGiOh.ApplicationServices.Service;
using YuGiOh.ApplicationCore.Repository;

namespace YuGiOh.Infrastructure.Service {
    public class CodeService : AbstractDataRepository, ICodeService
    {
        public CodeService(IDataRepository dataRepository) :
            base(dataRepository){  }  

        public async Task<string> GenerateAsync()
        {
            string random = RandomGenerator();
            await SetAsync(random);
            return random;
        }

        public async Task<string> GetAsync()
        {            
            Code code = (await _dataRepository.GetAllAsync<Code>()).ToList()[0];
            return code.Text;
        }

        public async Task SetAsync(string text)
        {
            List<Code> code = (await _dataRepository.GetAllAsync<Code>()).ToList();
            if (code.Count() == 0) {
                await _dataRepository.CreateAsync<Code>(new Code() { Id = Guid.NewGuid(), Text = text});
            }
            else {
                code[0].Text = text;
                await _dataRepository.UpdateAsync<Code>(code[0]);
            }
        }

        protected string RandomGenerator() {
            string result = new Random().NextDouble().ToString();
            return result;
        }
    }
}