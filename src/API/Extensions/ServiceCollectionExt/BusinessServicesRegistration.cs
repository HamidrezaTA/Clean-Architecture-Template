using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Implementations;
using Application.Services.Interfaces;

namespace API.Extensions.ServiceCollectionExt
{
    public static class BusinessServicesRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<ISampleService, SampleService>();
        }
    }
}