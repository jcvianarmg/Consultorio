using Consult.Manager.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace Consult.WebApi.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(NovoPacienteMappingProfile),
                typeof(AlteraPacienteMappingProfile)
                );//,
                //typeof(NovoMedicoMappingProfile),
                //typeof(UsuarioMappingProfile));
        }
    }
}
