using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repositories.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Repositories.UnitOfWork
{
    public static class UnitOfWorkRegistration
    {
        public static void AddEfUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, EfUnitOfWork>();
        }
    }
}