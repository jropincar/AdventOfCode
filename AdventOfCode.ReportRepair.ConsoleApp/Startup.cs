using System;
using System.Collections.Generic;
using System.Text;
using AdventOfCode.Models.ReportRepair;
using AdventOfCode.Services.Interfaces;
using AdventOfCode.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.ReportRepair.ConsoleApp
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
            var reportRepairConfig = new ReportRepairConfig();
            Configuration.GetSection("ReportRepairConfig").Bind(reportRepairConfig);
            serviceCollection.AddSingleton(reportRepairConfig);
            serviceCollection.AddSingleton<IServices, ReportRepairServices>();
        }
    }
}
