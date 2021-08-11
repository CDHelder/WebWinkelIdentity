using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWinkelIdentity.Data.GenericRepositoryTest;
using WebWinkelIdentity.Data.Service;
using WebWinkelIdentity.Data.Service.GenericRepositoryTest;
using WebWinkelIdentity.Data.Service.Interfaces;

namespace WebWinkelIdentity.Web.ServicesExtensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureAllDependencyInjections(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
