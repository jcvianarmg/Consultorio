using Consult.Data.Repository;
using Consult.Manager.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Consult.WebApi.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IPacienteRepository, PacienteRepository>();
            //services.AddScoped<IPacienteManager, PacienteManager>();
            //services.AddScoped<IMedicoRepository, MedicoRepository>();
            //services.AddScoped<IMedicoManager, MedicoManager>();
            //services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();
            //services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            //services.AddScoped<IUsuarioManager, UsuarioManager>();
        }
    }
}
