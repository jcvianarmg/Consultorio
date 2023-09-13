using Consult.WebApi.Configuration;

namespace Consult.WebApi;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddJwtTConfiguration(Configuration);

        services.AddFluentValidationConfiguration();

        services.AddAutoMapperConfiguration();

        services.AddDatabaseConfiguration(Configuration);

        services.AddDependencyInjectionConfiguration();

        services.AddSwaggerConfiguration();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseExceptionHandler("/error");

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseDatabaseConfiguration();

        app.UseSwaggerConfiguration();

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseJwtConfiguration();

        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}