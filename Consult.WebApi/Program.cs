//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Hosting;
//using Serilog;
//using System;
//using System.IO;


//namespace Consult.WebApi
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {

//            IConfigurationRoot configuration = GetConfiguration();
//            ConfigurationLog(configuration);

//            try
//            {
//                Log.Information("Iniciando a API");
//            }
//            catch (Exception ex)
//            {
//                Log.Fatal(ex, "Erro inesperado.");
//                throw;
//            }
//            finally
//            { 
//                Log.CloseAndFlush(); 
//            }
//        }

//        private static void ConfigurationLog(IConfigurationRoot configuration)
//        {
//            Log.Logger = new LoggerConfiguration()
//                .ReadFrom.Configuration(configuration)
//                .CreateLogger();
//        }

//        private static IConfigurationRoot GetConfiguration()
//        {
//            string ambiente = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

//            var configuration = new ConfigurationBuilder()
//                .SetBasePath(Directory.GetCurrentDirectory())
//                .AddJsonFile("appsettings.json")
//                .AddJsonFile($"appsettings.{ambiente}.json", optional: true)
//                .Build();
//            return configuration;
//        }

//        public static IHostBuilder CreateHostBuilder(string[] args) =>
//            Host.CreateDefaultBuilder(args)
//            .UseSerilog()
//                .ConfigureWebHostDefaults(webBuilder =>
//                {
//                    webBuilder.UseStartup<Startup>();
//                });
//    }
//}
using Consult.WebApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consult.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
