using Consult.Manager.Validator;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Globalization;

namespace Consult.WebApi.Configuration
{
    public static class FluentValidationConfig
    {
        [Obsolete]
        public static void AddFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddControllers()
            .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                .AddFluentValidation(p =>
                {
                    p.RegisterValidatorsFromAssemblyContaining<NovoPacienteValidator>();
                    p.RegisterValidatorsFromAssemblyContaining<AlteraPacienteValidator>();
                    p.RegisterValidatorsFromAssemblyContaining<NovoEnderecoValidator>();
                    p.RegisterValidatorsFromAssemblyContaining<NovoTelefoneValidator>();
                    p.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
                });
             //    .AddNewtonsoftJson(x =>
             //    {
             //        x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
             //        x.SerializerSettings.Converters.Add(new StringEnumConverter());
             //    })
             //    .AddJsonOptions(p => p.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
             //    .AddFluentValidation(p =>
             //    {
             //        p.RegisterValidatorsFromAssemblyContaining<NovoPacienteValidator>();
             //        p.RegisterValidatorsFromAssemblyContaining<NovoEnderecoValidator>();
             //        p.RegisterValidatorsFromAssemblyContaining<AlteraPacienteValidator>();
             //        p.RegisterValidatorsFromAssemblyContaining<NovoTelefoneValidator>();
             //        p.RegisterValidatorsFromAssemblyContaining<NovoMedicoValidator>();
             //        p.RegisterValidatorsFromAssemblyContaining<AlteraMedicoValidator>();
             //       // p.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
             //    });

        }
    }
}
