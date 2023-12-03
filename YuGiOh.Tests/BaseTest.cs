using YuGiOh.Infrastructure;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using YuGiOh.ApplicationCore.Repository;
using YuGiOh.ApplicationServices.Service;
using YuGiOh.Domain.Models;
using YuGiOh.Infrastructure.Service;
using YuGiOh.Infrastructure.Repository;
using YuGiOh.ApplicationServices.Seed;

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


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services
                .AddScoped<IEntityRepository, EntityRepository>()
                .AddScoped<ICodeService, CodeService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IRoleService, RoleService>()
                .AddScoped<IDeckService, DeckService>()
                .AddScoped<IRequestService, RequestService>()
                .AddScoped<ITournamentServices, TournamentServices>()
                .AddScoped<IArchetypeService, ArchetypeService>()
                .AddScoped<RoleSeed>()
                .AddScoped<CodeSeed>()
                .AddScoped<ArchetypeDbBootstrap>();

            // services.AddControllers()
            //     .AddNewtonsoftJson(options =>
            //     {
            //         // Configuración global para ignorar propiedades nulas durante la serialización
            //         options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            //     });

            // services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            // services.AddHttpClient();

            // typeof(Startup).Assembly.GetExportedTypes()
            //     .Where(c => c.BaseType == typeof(ControllerBase) || c.BaseType == typeof(Controller))
            //     .ToList().ForEach(t => services.AddScoped(t));
    }
    [Fact]
    public void Test1()
    {
        // Assert
        Assert.True(true);
    }
    public void Dispose()
    {
        Container.GetService<YuGiOhDbContext>().Database.EnsureDeleted();
    }
}