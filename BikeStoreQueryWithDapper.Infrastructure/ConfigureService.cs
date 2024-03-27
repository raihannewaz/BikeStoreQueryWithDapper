using BikeStoreQueryWithDapper.Application.CommonCQRS;
using BikeStoreQueryWithDapper.Domain.BrandEntity;
using BikeStoreQueryWithDapper.Domain.CategoryEntity;
using BikeStoreQueryWithDapper.Domain.CommonQueryInterface;
using BikeStoreQueryWithDapper.Domain.CustomerEntity;
using BikeStoreQueryWithDapper.Domain.OrderItemEntity;
using BikeStoreQueryWithDapper.Domain.StockEntity;
using BikeStoreQueryWithDapper.Infrastructure.Brand;
using BikeStoreQueryWithDapper.Infrastructure.Category;
using BikeStoreQueryWithDapper.Infrastructure.CommonQueryRepo;
using BikeStoreQueryWithDapper.Infrastructure.Customer;
using BikeStoreQueryWithDapper.Infrastructure.DATA;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreQueryWithDapper.Infrastructure
{
    public static class ConfigureService
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BikeStoresContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbCon"));
            });


            services.AddTransient<DapperDbContext>();
            
            services.AddScoped(typeof(IBrandRepository) ,typeof (BrandRepository));
            services.AddScoped(typeof(ICategoryRepository) ,typeof (CategoryRepository));
            services.AddScoped(typeof(ICustomerRepository) ,typeof (CustomerRepository));
            services.AddScoped(typeof(ICommonQueryInterface<CommonDTO>) ,typeof (CommonQueryRepository<CommonDTO>));
            services.AddScoped(typeof(ICommonQueryInterface<Stock>) ,typeof (CommonQueryRepository<Stock>));


            return services;
        }
    }
}
