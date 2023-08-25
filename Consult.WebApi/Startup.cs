using Consult.Data.Context;
using Consult.Data.Repository;
using Consult.Manager.Implementation;
using Consult.Manager.Interfaces;
using Consult.Manager.Mappings;
using Consult.Manager.Validator;
using Consult.WebApi.Configuration;
using Consult.WebApi.Controllers;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace Consult.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
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
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
