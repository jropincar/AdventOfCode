using AdventOfCode.Models;
using AdventOfCode.Models.PasswordPolicy;
using AdventOfCode.Services.Services;
using AdventOfCode.Services.Interfaces;
using AdventOfCode.Services.Mappers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.PasswordPolicy.ConsoleApp
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
            var passwordPolicyConfig = new PasswordPolicyConfig();
            Configuration.GetSection("PasswordPolicyConfig").Bind(passwordPolicyConfig);
            serviceCollection.AddSingleton(passwordPolicyConfig);
            serviceCollection.AddSingleton<IServices, PasswordPolicyServices>();
            serviceCollection.AddSingleton(new PasswordPolicyMapper());
        }
    }
}
