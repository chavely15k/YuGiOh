using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.ApplicationCore.Repository;
using YuGiOh.ApplicationServices.Service;
using YuGiOh.Domain.Models;
using YuGiOh.Infrastructure;
using YuGiOh.Infrastructure.Repository;

namespace YuGiOh.Tests {
    public class CodeCreateTest : BaseTest {
        private ICodeService codeService;
        public CodeCreateTest() {
            codeService = Container.GetRequiredService<ICodeService>();
        }
        [Fact]
        public async Task SetCodeTestAsync() {
            await codeService.SetAsync("test1");
            var code = await codeService.GetAsync();
            Assert.True(code == "test1");
        }
        [Fact]
        public async Task GenerateCodeTestAsync() {
            var code = await codeService.GenerateAsync();
            var result = await codeService.GetAsync();
            Assert.True(code == result);
        }
    }
    public class CodeSetTest : BaseTest{
        private ICodeService codeService;
        public CodeSetTest() {
            codeService = Container.GetRequiredService<ICodeService>();
        }
        [Fact]
        public async Task GetCodeTestAsync() {
            var code = await codeService.GetAsync();
            Console.WriteLine(code);
            Assert.True(code == "1234abcd");
        }
    }
}
