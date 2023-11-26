using Microsoft.EntityFrameworkCore;
using YuGiOh.ApplicationServices.Service;
using YuGiOh.ApplicationCore.Repository;
using YuGiOh.Infrastructure;
using YuGiOh.ApplicationServices.Seed;
using YuGiOh.Infrastructure.Service;
using YuGiOh.Infrastructure.Repository;
using YuGiOh.Infrastructure.Mappings;
using Microsoft.Extensions.DependencyInjection;

// using YuGiOh.Infrastructure.Seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<YuGiOhDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")!, x => x.MigrationsAssembly("YuGiOh.Infrastructure"));
});
//builder.Services.AddAutoMapper(typeof(Program).Assembly,typeof(AutoMapperProfile).Assembly);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services
    .AddScoped<IDataRepository, DataRepository>()
    .AddScoped<ICodeService, CodeService>()
    .AddScoped<IUserService, UserService>()
    .AddScoped<IDeckService, DeckService>()
//     .AddScoped<CodeController>()
     .AddScoped<CodeSeed>()
//     .AddScoped<RoleSeed>()
;


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

var serviceProvider = app.Services.CreateScope().ServiceProvider;
InitializeData(app, serviceProvider);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();

static async void InitializeData(WebApplication app, IServiceProvider serviceProvider)
{
    await serviceProvider.GetService<CodeSeed>()!.SetInitialCodeAsync();
    //await serviceProvider.GetService<RoleSeed>()!.SetInitialRoleAsync();
}
