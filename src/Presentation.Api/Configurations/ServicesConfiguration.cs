namespace Presentation.Api.Configurations
{
    using Application.Services;
    using Data.Repository;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class ServicesConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IMedicationService, MedicationService>();
            services.AddScoped<IMedicationRepository, MedicationRepository>();

            return services;
        }
    }
}