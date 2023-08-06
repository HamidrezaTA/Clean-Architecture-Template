using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistance.EFCore
{
    public static class EFCoreRegistration
    {
        public static void AddEFCoreMySqlDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SampleDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        }
    }
}