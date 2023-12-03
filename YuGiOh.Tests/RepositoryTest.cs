using Microsoft.Extensions.DependencyInjection;
using YuGiOh.Infrastructure;

namespace YuGiOh.Tests {
    public class RepositoryTest : BaseTest {
        private YuGiOhDbContext _ctx;
        public RepositoryTest() {
            _ctx = Container.GetRequiredService<YuGiOhDbContext>();
        }

        [Fact]
        public void CreateTest() {
        // Assert
        Assert.True(true);
        }
    }
}