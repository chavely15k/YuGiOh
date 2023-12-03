using YuGiOh.Infrastructure;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration.Json;

namespace YuGiOh.Tests;

public abstract class BaseTest
{
    public readonly static InMemoryDatabaseRoot InMemoryDatabaseRoot = new InMemoryDatabaseRoot();

    public IConfiguration Configuration;

    public ServiceCollection services;

    public ServiceProvider Container =>
        services.BuildServiceProvider();
    public BaseTest() { 
            services = new ServiceCollection();

            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("./appsettings.json")
                .Build();
            
            services.AddTransient(c => Configuration);

            services.AddDbContext<YuGiOhDbContext>(opt =>
                opt.UseInMemoryDatabase("testing", InMemoryDatabaseRoot), ServiceLifetime.Transient);


            // services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            // services.AddHttpClient();

            // typeof(Startup).Assembly.GetExportedTypes()
            //     .Where(c => c.BaseType == typeof(ControllerBase) || c.BaseType == typeof(Controller))
            //     .ToList().ForEach(t => services.AddScoped(t));

            var writeCtx = Container.GetRequiredService<YuGiOhDbContext>();
            //SeedData.EnsureDbSeeded(writeCtx);
    }
    [Fact]
    public void Test1()
    {
        // Assert
        Assert.True(true);
    }
}