using AdventOfCode.Models.PassportProcessing;
using AdventOfCode.Services.Interfaces;
using AdventOfCode.Services.Services;
using AdventOfCode.Services.Services.Validators;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.PassportProcessing.ConsoleApp
{
    public class Startup
    {
        IConfigurationRoot Configuration { get; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json");

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            var passportProcessingConfig = new PassportProcessingConfig();
            Configuration.GetSection("PassportProcessingConfig").Bind(passportProcessingConfig);
            serviceCollection.AddSingleton(passportProcessingConfig);
            serviceCollection.AddSingleton<IPassportValidator, PassportValidator>();
            serviceCollection.AddSingleton<IServices, PassportProcessingServices>();
        }
    }
}
