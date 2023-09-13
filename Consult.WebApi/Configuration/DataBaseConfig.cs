using Consult.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Consult.WebApi.Configuration;

public static class DataBaseConfig
{
    public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ConsultContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConConnection")));
    }

    public static void UseDatabaseConfiguration(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        using var context = serviceScope.ServiceProvider.GetService<ConsultContext>();
        context.Database.Migrate();
        context.Database.EnsureCreated();
    }
}